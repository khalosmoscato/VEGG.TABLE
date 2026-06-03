namespace VEGG.TABLE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProduceController : ControllerBase
{
    private readonly IProduceService _produceService;

    public ProduceController(IProduceService produceService)
    {
        _produceService = produceService;
    }

    // GET: api/produce
    [HttpGet]
    public IActionResult GetAllProduces()
    {
        return Ok(_produceService.GetAllProduces());
    }

    // GET: api/produce/1
    [HttpGet("{id}")]
    public IActionResult GetProduceById(int id)
    {
        var produce = _produceService.GetProduceById(id);

        if (produce == null) return NotFound();

        return Ok(produce);
    }

    // GET: api/produce/seller/1/

    [HttpGet("/produce/seller/{id}")]
    public IActionResult GetProduceByUserId(int userId)
    {
        List<Produce>? produceList = _produceService.GetProduceByUserId(userId);

        if (produceList == null) return NotFound();

        return Ok(produceList);
    }

    // POST: api/produce
    [HttpPost]
    public IActionResult AddProduce(Produce produce)
    {
        var created = _produceService.AddProduce(produce);
        return CreatedAtAction(nameof(GetProduceById), new { id = created.ProduceId }, created);
    }

    // DELETE: api/produce/1
    [HttpDelete("{id}")]
    public IActionResult DeleteProduce(int id)
    {
        var result = _produceService.DeleteProduce(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}