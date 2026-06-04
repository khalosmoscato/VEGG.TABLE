using System.Collections;

using Microsoft.AspNetCore.Mvc;

using VEGG.TABLE.UnitTests.Resources;

namespace VEGG.TABLE.UnitTests.Services;

public class ProduceServiceTests
{
    private Mock<IProduceRepository> _mockRepo = null!;
    private ProduceService _service = null!;

    private static List<Produce> testProduce = new List<Produce> { };

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IProduceRepository>();
        _service = new ProduceService(_mockRepo.Object);

        testProduce = DummyProduce.DummyProduceList;
    }

    [Test]
    public void GetAllProduces_ReturnsAllFromRepository()
    {
        //ARRANGE
        var produces = testProduce;
        _mockRepo.Setup(r => r.GetAllProduces()).Returns(testProduce);
        //ACT
        var result = _service.GetAllProduces();
        //ASSERT
        result.Should().BeEquivalentTo(testProduce);
    }

    [Test]
    public void GetAllProducesOnSale_ReturnsAllOnSaleProduce()
    {
        //arrange
        List<Produce> produces = testProduce;
        List<Produce>? expectedProduces = produces.Where(p => p.IsOnSale == true).ToList();
        if (expectedProduces.Count == 0)
        {
            expectedProduces = null;
        }
        _mockRepo.Setup(r => r.GetAllProduceOnSale()).Returns(expectedProduces);

        //Act
        List<Produce>? result = _service.GetAllProduceOnSale();

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetAllProduceOnSale(), Times.Once);
        //check result type
        Assert.IsInstanceOf<List<Produce>>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EquivalentTo(expectedProduces));
    }

    [Test]
    public void GetAllProducesOnSale_ReturnsEmptyProduceWhenNothingOnSale()
    {
        //arrange
        List<Produce> produces = new List<Produce>(); ;
        List<Produce>? expectedProduces = produces.Where(p => p.IsOnSale == true).ToList();
        if (expectedProduces.Count == 0)
        {
            expectedProduces = null;
        }
        _mockRepo.Setup(r => r.GetAllProduceOnSale()).Returns(expectedProduces);

        //Act
        var result = _service.GetAllProduceOnSale();

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetAllProduceOnSale(), Times.Once);
        //check result type
        Assert.IsNull(result);

    }

    [Test]
    public void GetProduceById_ReturnsProduce_WhenFound()
    {
        //ARRANGE
        var produce = new Produce { ProduceId = 1, Name = "Apples", UserId = 1 };
        _mockRepo.Setup(r => r.GetProduceById(1)).Returns(produce);
        //ACT
        var result = _service.GetProduceById(1);
        //ASSERT
        result.Should().Be(produce);
    }

    [Test]
    public void GetProduceById_ReturnsNull_WhenNotFound()
    {
        //ARRANGE
        _mockRepo.Setup(r => r.GetProduceById(99)).Returns((Produce?)null);
        //ACT
        var result = _service.GetProduceById(99);

        result.Should().BeNull();
    }

    [Test]
    public void AddProduce_ReturnsCreatedProduce()
    {
        //ARRANGE
        var produceList = testProduce;
        var produceDTO = new CreateProduceDTO { Name = "Apples", UserId = 1, Stock =5, Description= "An Apple", IsOnSale = true, Price = 2.00};
        var produce = new Produce { ProduceId = 8, Name = "Apples", UserId = 1 };
        _mockRepo.Setup(r => r.AddProduce(produceDTO)).Returns(produce);
        //ACT
        var result = _service.AddProduce(produceDTO);
        //ASSERT
        result.Should().Be(produce);
        _mockRepo.Verify(r => r.AddProduce(produceDTO), Times.Once);
    }

    [Test]
    public void DeleteProduce_ReturnsTrue_WhenDeleted()
    {
        //ARRANGE
        _mockRepo.Setup(r => r.DeleteProduce(1)).Returns(true);
        //ACT
        var result = _service.DeleteProduce(1);
        //ASSERT
        result.Should().BeTrue();
    }

    [Test]
    public void DeleteProduce_ReturnsFalse_WhenNotFound()
    {
        //ARRANGE
        _mockRepo.Setup(r => r.DeleteProduce(99)).Returns(false);
        //ACT
        var result = _service.DeleteProduce(99);
        //ASSERT
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