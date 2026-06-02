namespace VEGG.TABLE.UnitTests.Services;

public class LikeServiceTests
{
    private Mock<ILikeRepository> _mockRepo = null!;
    private LikeService _service = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<ILikeRepository>();
        _service = new LikeService(_mockRepo.Object);
    }

    [Test]
    public void AddLike_ReturnsLike_FromRepository()
    {
        var like = new UserProduceLike
        {
            UserId = 1, User = null!, ProduceId = 2, Produce = null!
        };
        _mockRepo.Setup(r => r.AddLike(1, 2)).Returns(like);

        var result = _service.AddLike(1, 2);

        result.Should().Be(like);
        _mockRepo.Verify(r => r.AddLike(1, 2), Times.Once);
    }

    [Test]
    public void AddLike_ReturnsNull_WhenRepositoryReturnsNull()
    {
        _mockRepo.Setup(r => r.AddLike(1, 99)).Returns((UserProduceLike?)null);

        var result = _service.AddLike(1, 99);

        result.Should().BeNull();
    }

    [Test]
    public void RemoveLike_ReturnsTrue_WhenRemoved()
    {
        _mockRepo.Setup(r => r.RemoveLike(1, 2)).Returns(true);

        var result = _service.RemoveLike(1, 2);

        result.Should().BeTrue();
    }

    [Test]
    public void RemoveLike_ReturnsFalse_WhenNotFound()
    {
        _mockRepo.Setup(r => r.RemoveLike(1, 99)).Returns(false);

        var result = _service.RemoveLike(1, 99);

        result.Should().BeFalse();
    }

    [Test]
    public void GetLikesByUser_ReturnsListFromRepository()
    {
        var likes = new List<UserProduceLike>
        {
            new() { UserId = 1, User = null!, ProduceId = 2, Produce = null! },
            new() { UserId = 1, User = null!, ProduceId = 3, Produce = null! }
        };
        _mockRepo.Setup(r => r.GetLikesByUser(1)).Returns(likes);

        var result = _service.GetLikesByUser(1);

        result.Should().BeEquivalentTo(likes);
    }

    [Test]
    public void GetLikesByUser_ReturnsEmptyList_WhenNoLikes()
    {
        _mockRepo.Setup(r => r.GetLikesByUser(99)).Returns(new List<UserProduceLike>());

        var result = _service.GetLikesByUser(99);

        result.Should().BeEmpty();
    }
}
