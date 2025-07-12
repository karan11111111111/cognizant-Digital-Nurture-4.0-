[Route("api/[controller]")]
[ApiController]
[AllowAnonymous] // Skip JWT auth for this controller
public class AuthController : ControllerBase
{
    [HttpGet("token")]
    public IActionResult GenerateToken(int userId, string userRole)
    {
        var token = GenerateJwtToken(userId, userRole);
        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(int userId, string userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, userRole),
            new Claim("UserId", userId.ToString())
        };
        var token = new JwtSecurityToken(
            issuer: "mySystem",
            audience: "myUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}