using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("clientes/")]
public class ClientsController : ControllerBase
{
    [HttpGet("{id}/extrato")]
    public IActionResult GetExtractsAsync([FromRoute] int id)
    {
        return Ok("Ok!");
    }
}