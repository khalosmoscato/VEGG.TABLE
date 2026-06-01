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
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
    // GET: api/user/1
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
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserDTO userDTO)
    {
        var result = _userService.UpdateUser(id, userDTO);

        if (result == null) return NotFound();

        return Created();
    }

    // PUT: api/user/name
    [HttpPut("{id}/name")]
    public IActionResult UpdateUserName(int id, string name)
    {
        var result = _userService.UpdateUserName(id, name);

        if (result == null) return NotFound();

        return Created();
    }

    // DELETE: api/user/1
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _userService.DeleteUser(id);

        bool success = result.Item1;

        if (!success)
            return NotFound();

        return NoContent();
    }
}