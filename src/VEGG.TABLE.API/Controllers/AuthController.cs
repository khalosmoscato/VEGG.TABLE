using Microsoft.AspNetCore.Identity;

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
    public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
    {
        // The framework handles password hashing and salt verification internally
        var result = await _signInManager.PasswordSignInAsync(
            loginDto.Email,
            loginDto.Password,
            isPersistent: false,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            return Ok("Login successful");
        }

        return Unauthorized("Invalid email or password.");
    }
}
