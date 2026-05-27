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
    public IActionResult AddUser(User user)
    {
        var created = _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
    }
}