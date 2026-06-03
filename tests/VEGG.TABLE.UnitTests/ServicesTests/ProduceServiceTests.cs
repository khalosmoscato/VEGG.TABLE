using VEGG.TABLE.UnitTests.Resources;

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

    [Test]
    public void DeleteProduce_ReturnsTrue_WhenDeleted()
    {
        _mockRepo.Setup(r => r.DeleteProduce(1)).Returns(true);

        var result = _service.DeleteProduce(1);

        result.Should().BeTrue();
    }

    [Test]
    public void DeleteProduce_ReturnsFalse_WhenNotFound()
    {
        _mockRepo.Setup(r => r.DeleteProduce(99)).Returns(false);

        var result = _service.DeleteProduce(99);

        result.Should().BeFalse();
    }

    [Test]
    public void GetProduceByUserIdAll_returnsProduce()
    {
        //Arrange
        var parameter = 1;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter).ToList();
        _mockRepo.Setup(r => r.GetProduceByUserIdAll(parameter)).Returns(expectedProduce);
        
        foreach(Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //Act
        var result = _service.GetProduceByUserIdAll(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetProduceByUserIdAll(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<List<Produce>>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EquivalentTo(expectedProduce));
    }

    [Test]
    public void GetProduceByUserIdAll_returnsNotFound()
    {
        //Arrange
        var parameter = 0;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter).ToList();
        _mockRepo.Setup(r => r.GetProduceByUserIdAll(parameter)).Returns(expectedProduce);

        foreach (Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //Act
        var result = _service.GetProduceByUserIdAll(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetProduceByUserIdAll(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<List<Produce>>(result);
        //check the data is matching expected
        Assert.That(result, Is.EquivalentTo(expectedProduce));
    }


    [Test]
    public void GetProduceByUserId_returnsProduceOnSale()
    {
        //ARRANGE
        var parameter = 1;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter && p.IsOnSale == true).ToList();
        _mockRepo.Setup(r => r.GetProduceByUserId(parameter)).Returns(expectedProduce);

        foreach (Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //ACT
        var result = _service.GetProduceByUserId(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetProduceByUserId(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<List<Produce>>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EquivalentTo(expectedProduce));
    }
}