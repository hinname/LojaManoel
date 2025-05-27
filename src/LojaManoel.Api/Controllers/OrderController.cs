using Microsoft.AspNetCore.Mvc;

namespace LojaManoel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType( StatusCodes.Status201Created)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ProccessOrder(
    )
    {
        return Created(string.Empty, null);
    }
}