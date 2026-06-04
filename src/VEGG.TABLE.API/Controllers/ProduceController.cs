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

     //GET: /api/produce/onsale
    [HttpGet("onsale")]
    public IActionResult GetAllProduceOnSale()
    {
        var onSale = _produceService.GetAllProduceOnSale();
        if (onSale != null)
        {
            return Ok(onSale);
        }
        else return NoContent();
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
    //Shows what is on sale for a particular seller
    [HttpGet("seller/{userId}")]
    public IActionResult GetProduceByUserId(int userId)
    {
        List<Produce>? produceList = _produceService.GetProduceByUserId(userId);

        if (produceList == null) return NotFound();
        
        if (!produceList.Any()) return NoContent();

        return Ok(produceList);
    }

    // GET: api/produce/seller/all/1
    [HttpGet("seller/all/{userId}")]
    public IActionResult GetProduceByUserIdAll(int userId)
    {
        List<Produce>? produceList = _produceService.GetProduceByUserIdAll(userId);

        if (produceList == null) return NotFound();

        if (!produceList.Any()) return NoContent();
        return Ok(produceList);
    }

    // POST: api/produce
    [HttpPost]
    public IActionResult AddProduce(CreateProduceDTO produceDTO)
    {
        var created = _produceService.AddProduce(produceDTO);
        return CreatedAtAction(nameof(GetProduceById), new { id = created.ProduceId }, created);
    }

    // PATCH: api/produce
    [HttpPatch]
    public IActionResult UpdateProduce(int id, ProduceDTO produceDTO)
    {
        var updated = _produceService.UpdateProduce(id, produceDTO);
        return Ok(updated);
    }

    // DELETE: api/produce/1
    [HttpDelete("{id}")]
    public IActionResult DeleteProduce(int id)
    {
        var result = _produceService.DeleteProduce(id);

        if (!result) { return NotFound(); }

        return NoContent();
    }
}