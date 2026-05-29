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
    public IActionResult UpdateUser(int id, User user)
    {
        var result = _userService.UpdateUser(id, user);

        if (result == null) return NotFound();

        return NoContent();
    }
    // DELETE: api/user/1
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _userService.DeleteUser(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}