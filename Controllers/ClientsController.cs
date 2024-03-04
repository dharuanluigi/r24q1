using Microsoft.AspNetCore.Mvc;

namespace r24q1.Controllers;

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