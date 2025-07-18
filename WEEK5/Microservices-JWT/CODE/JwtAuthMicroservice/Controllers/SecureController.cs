using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    [HttpGet("data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        return Ok(new { 
            Message = "This is protected data.",
            User = User.Identity?.Name ?? "Unknown",
            Claims = User.Claims.Select(c => new { c.Type, c.Value })
        });
    }
}