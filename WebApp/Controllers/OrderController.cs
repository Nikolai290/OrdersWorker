using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using OrderWorker.Business.Interfaces.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    [HttpPost("{systemType}")]
    public async Task<ActionResult> AddOrderAsync(
        [FromRoute] string systemType,
        [FromBody] JsonDocument requestBodyJson,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _orderService.AddOrderAsync(systemType, requestBodyJson, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}