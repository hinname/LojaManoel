using LojaManoel.Application.UseCases.Order.Register;
using LojaManoel.Communication.Requests.Order;
using LojaManoel.Communication.Responses.Order;
using Microsoft.AspNetCore.Mvc;

namespace LojaManoel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredOrderJson), StatusCodes.Status201Created)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterOrder(
        [FromServices] IRegisterOrderUseCase useCase,
        [FromBody] RequestOrderJson request
    )
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, null);
    }
}