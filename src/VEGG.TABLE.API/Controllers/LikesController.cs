namespace VEGG.TABLE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikesController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    // POST: api/likes
    [HttpPost]
    public IActionResult AddLike(LikeRequestDTO request)
    {
        var like = _likeService.AddLike(request.UserId, request.ProduceId);
        if (like == null) return BadRequest();
        return Ok(like);
    }

    // DELETE: api/likes?userId=1&produceId=2
    [HttpDelete]
    public IActionResult RemoveLike([FromQuery] int userId, [FromQuery] int produceId)
    {
        var removed = _likeService.RemoveLike(userId, produceId);
        if (!removed) return NotFound();
        return NoContent();
    }

    // GET: api/likes/user/1
    [HttpGet("user/{userId}")]
    public IActionResult GetLikesByUser(int userId)
    {
        return Ok(_likeService.GetLikesByUser(userId));
    }
}
