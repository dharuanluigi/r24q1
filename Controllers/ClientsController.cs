using System.Net;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using r24q1.Contexts;
using r24q1.DTOs;
using r24q1.Entity;

namespace r24q1.Controllers;

[ApiController]
[Route("clientes/")]
public class ClientsController : ControllerBase
{
    private ClientContext _db;

    public ClientsController(ClientContext clientContext)
    {
        _db = clientContext;
    }

    [HttpPost("{id}/transacoes")]
    public IActionResult RegisterANewTransaction([FromRoute] int id, [FromBody] NewTransaction newTransaction)
    {
        try
        {
            var client = _db.Set<Client>().Find(id);

            if (client is null)
            {
                return NotFound("Usuário não econtrado");
            }

            client.Withdraw(newTransaction.Valor);
            _db.Set<Client>().Update(client);
            _db.Set<Transaction>().Add(new Transaction(0, newTransaction.Valor, newTransaction.Tipo, newTransaction.Descricao, DateTime.UtcNow, client.Id, client));
            _db.SaveChanges();

            return Ok(new {limite = client.Limit, saldo = client.Balance});
        }
        catch (InvalidParameterException)
        {
            return UnprocessableEntity();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}/extrato")]
    public IActionResult GetExtracts([FromRoute] int id)
    {
        var queryClient = from c in _db.Set<Client>()
                          where c.Id == id
                          select c;

        var client = queryClient.FirstOrDefault();

        if (client is null)
        {
            return NotFound("Usuário não encontrado.");
        }

        var transactions = from t in _db.Set<Transaction>()
                           where t.Client.Id == id
                           orderby t.ProcessAt descending
                           select new Extract(t.Value, t.Type, t.Description, t.ProcessAt);

        return Ok(new ApiSuccess(new Balance(client.Balance, DateTime.UtcNow, client.Limit), transactions.Take(10)));
    }
}