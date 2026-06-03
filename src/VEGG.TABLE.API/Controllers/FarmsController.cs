namespace VEGG.TABLE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmsController : ControllerBase
{
    private readonly IFarmService _service;

    public FarmsController(IFarmService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Farm>>> GetFarms()
    {
        return Ok(await _service.GetFarms());
    }
}