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
}