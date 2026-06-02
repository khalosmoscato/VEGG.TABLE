using Microsoft.AspNetCore.Mvc;

namespace VEGG.TABLE.UnitTests.Controllers;

public class LikesControllerTests
{
    private Mock<ILikeService> _mockService = null!;
    private LikesController _controller = null!;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<ILikeService>();
        _controller = new LikesController(_mockService.Object);
    }

    [Test]
    public void AddLike_ReturnsOk_WithLike()
    {
        var like = new UserProduceLike
        {
            UserId = 1, User = null!, ProduceId = 2, Produce = null!
        };
        _mockService.Setup(s => s.AddLike(1, 2)).Returns(like);

        var result = _controller.AddLike(new LikeRequestDTO { UserId = 1, ProduceId = 2 });

        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().Be(like);
    }

    [Test]
    public void AddLike_ReturnsBadRequest_WhenServiceReturnsNull()
    {
        _mockService.Setup(s => s.AddLike(1, 99)).Returns((UserProduceLike?)null);

        var result = _controller.AddLike(new LikeRequestDTO { UserId = 1, ProduceId = 99 });

        result.Should().BeOfType<BadRequestResult>();
    }

    [Test]
    public void RemoveLike_ReturnsNoContent_WhenRemoved()
    {
        _mockService.Setup(s => s.RemoveLike(1, 2)).Returns(true);

        var result = _controller.RemoveLike(1, 2);

        result.Should().BeOfType<NoContentResult>();
    }

    [Test]
    public void RemoveLike_ReturnsNotFound_WhenNotFound()
    {
        _mockService.Setup(s => s.RemoveLike(1, 99)).Returns(false);

        var result = _controller.RemoveLike(1, 99);

        result.Should().BeOfType<NotFoundResult>();
    }

    [Test]
    public void GetLikesByUser_ReturnsOk_WithList()
    {
        var likes = new List<UserProduceLike>
        {
            new() { UserId = 1, User = null!, ProduceId = 2, Produce = null! }
        };
        _mockService.Setup(s => s.GetLikesByUser(1)).Returns(likes);

        var result = _controller.GetLikesByUser(1);

        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(likes);
    }

    [Test]
    public void GetLikesByUser_ReturnsOk_WithEmptyList()
    {
        _mockService.Setup(s => s.GetLikesByUser(99)).Returns(new List<UserProduceLike>());

        var result = _controller.GetLikesByUser(99);

        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(new List<UserProduceLike>());
    }
}
