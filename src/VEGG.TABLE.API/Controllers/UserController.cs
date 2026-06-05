using Microsoft.AspNetCore.Authorization;

namespace VEGG.TABLE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    // GET: api/user
    // [Authorize(Roles = "Admin")] // Shop page is not working if Authorization atm
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
    // GET: api/user/1
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null) return NotFound();

        return Ok(user);
    }


    // POST: api/user
    [HttpPost]
    public IActionResult AddUser(UserDTO userDTO)
    {
        var created = _userService.AddUser(userDTO);
        return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
    }
    // PUT: api/user/1
    [Authorize(Roles = "Buyer,Seller")]
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserDTO userDTO)
    {
        var result = _userService.UpdateUser(id, userDTO);

        if (result == null) return NotFound();

        return Ok(result);
    }

    // PUT: api/user/name
    [Authorize(Roles = "Buyer,Seller")]
    [HttpPut("{id}/name")]
    public IActionResult UpdateUserName(int id, string name)
    {
        var result = _userService.UpdateUserName(id, name);

        if (result == null) return NotFound();

        return Ok(result);
    }

    // DELETE: api/user/1
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _userService.DeleteUser(id);

        bool success = result.Item1;

        if (!success)
            return NotFound();

        return NoContent();
    }

    // GET: api/user/profile
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetCurrentProfile()
    {
        // Ensure you are using System.Security.Claims here
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
        {
            return Unauthorized();
        }

        var user = _userService.GetUserById(userId);
        return user == null ? NotFound() : Ok(user);
    }
}