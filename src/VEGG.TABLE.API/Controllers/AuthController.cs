using VEGG.TABLE.Core.Entities.DTOs;

namespace VEGG.TABLE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDTO loginDto)
    {
        var userResponse = _authService.Authenticate(loginDto.Email, loginDto.Password);

        if (userResponse == null)
        {
            // Returning Unauthorized (401) is the standard for failed logins
            return Unauthorized("Invalid email or password.");
        }

        // Return the user DTO upon successful login
        return Ok(userResponse);
    }
}