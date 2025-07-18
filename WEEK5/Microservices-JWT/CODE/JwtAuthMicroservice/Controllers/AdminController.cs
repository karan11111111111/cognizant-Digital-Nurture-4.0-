using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminDashboard()
    {
        return Ok(new { 
            Message = "Welcome to the admin dashboard.",
            User = User.Identity?.Name ?? "Unknown",
            IsAdmin = User.IsInRole("Admin")
        });
    }
}