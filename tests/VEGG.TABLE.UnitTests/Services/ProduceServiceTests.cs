namespace VEGG.TABLE.UnitTests.Services;

public class ProduceServiceTests
{
    private Mock<IProduceRepository> _mockRepo = null!;
    private ProduceService _service = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IProduceRepository>();
        _service = new ProduceService(_mockRepo.Object);
    }

    [Test]
    public void GetAllProduces_ReturnsAllFromRepository()
    {
        var produces = new List<Produce>
        {
            new Produce { ProduceId = 1, Name = "Apples", UserId = 1 },
            new Produce { ProduceId = 2, Name = "Bananas", UserId = 2 }
        };
        _mockRepo.Setup(r => r.GetAllProduces()).Returns(produces);

        var result = _service.GetAllProduces();

        result.Should().BeEquivalentTo(produces);
    }

    [Test]
    public void GetProduceById_ReturnsProduce_WhenFound()
    {
        var produce = new Produce { ProduceId = 1, Name = "Apples", UserId = 1 };
        _mockRepo.Setup(r => r.GetProduceById(1)).Returns(produce);

        var result = _service.GetProduceById(1);

        result.Should().Be(produce);
    }

    [Test]
    public void GetProduceById_ReturnsNull_WhenNotFound()
    {
        _mockRepo.Setup(r => r.GetProduceById(99)).Returns((Produce?)null);

        var result = _service.GetProduceById(99);

        result.Should().BeNull();
    }

    [Test]
    public void AddProduce_ReturnsCreatedProduce()
    {
        var produce = new Produce { ProduceId = 1, Name = "Apples", UserId = 1 };
        _mockRepo.Setup(r => r.AddProduce(produce)).Returns(produce);

        var result = _service.AddProduce(produce);

        result.Should().Be(produce);
        _mockRepo.Verify(r => r.AddProduce(produce), Times.Once);
    }
}
