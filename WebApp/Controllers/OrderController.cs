using Microsoft.AspNetCore.Mvc;
using WebApp.Dtos;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OrderController : ControllerBase
{
    
    [HttpPost("{systemType}")]

    public async Task<ActionResult> AddOrderAsync([FromRoute] string systemType, [FromBody] AddOrderDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
        
    }
    
}