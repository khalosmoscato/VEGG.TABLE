using System.Data.Common;
using System.Reflection.Metadata;

using Microsoft.AspNetCore.Mvc;

using VEGG.TABLE.UnitTests.Resources;

namespace VEGG.TABLE.UnitTests.Services;

public class ProduceControllerTests
{
    private Mock<IProduceService> _mockService = null!;
    private ProduceController _controller = null!;

    private static List<Produce> testProduce = new List<Produce> { };

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IProduceService>();
        _controller = new ProduceController(_mockService.Object);

        testProduce = DummyProduce.DummyProduceList;
    }

    [Test]
    public void GetAllProduces_ReturnsAllFromService()
    {
        //arrange
        var produces = testProduce;

        _mockService.Setup(s => s.GetAllProduces()).Returns(produces);

        //Act
        var result = _controller.GetAllProduces();

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetAllProduces(), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as List<Produce>;
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(resultPayload, Is.EquivalentTo(produces));
    }

    [Test]
    public void GetAllProducesOnSale_ReturnsAllOnSaleProduce()
    {
        //arrange
        List<Produce> produces = testProduce;
        var expectedProduces = produces.Where(p => p.IsOnSale == true).ToList();
        if (expectedProduces.Count == 0)
        {
            expectedProduces = null;
        }
        _mockService.Setup(s => s.GetAllProduceOnSale()).Returns(expectedProduces);

        //Act
        var result = _controller.GetAllProduceOnSale();

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetAllProduceOnSale(), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as List<Produce>;
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(resultPayload, Is.EquivalentTo(expectedProduces));
    }

    [Test]
    public void GetAllProducesOnSale_ReturnsEmptyProduceWhenNothingOnSale()
    {
        //arrange
        List<Produce> produces = new List<Produce>();
        List<Produce>? expectedProduces = produces.Where(p => p.IsOnSale == true).ToList();
        if (expectedProduces.Count == 0)
        {
            expectedProduces = null;
        }
        _mockService.Setup(s => s.GetAllProduceOnSale()).Returns(expectedProduces);

        //Act
        var result = _controller.GetAllProduceOnSale();

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetAllProduceOnSale(), Times.Once);
        //check result type
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Test]
    public void GetProduceById_ReturnsProduce_WhenFound()
    {
        var produce = new Produce { ProduceId = 1, Name = "Apples", UserId = 1 };
        _mockService.Setup(s => s.GetProduceById(1)).Returns(produce);

        var result = _controller.GetProduceById(1);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceById(1), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as Produce;
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(resultPayload, Is.EqualTo(produce));

    }

    [Test]
    public void GetProduceById_ReturnsNull_WhenNotFound()
    {
        _mockService.Setup(s => s.GetProduceById(99)).Returns((Produce?)null);

        var result = _controller.GetProduceById(99);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceById(99), Times.Once);
        //check result type
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void AddProduce_ReturnsCreatedProduce()
    {
        var produce = new Produce { ProduceId = 1, Name = "Apples", UserId = 1 };
        _mockService.Setup(s => s.AddProduce(produce)).Returns(produce);

        var result = _controller.AddProduce(produce);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.AddProduce(produce), Times.Once);
        //check result type
        Assert.IsInstanceOf<CreatedAtActionResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as CreatedAtActionResult;
        var resultPayload = resultObject?.Value as Produce;
        //check the data is matching expected
        Assert.That(resultPayload, Is.EqualTo(produce));
        //Assert.That(users, Is.EquivalentTo(expectedUsers))
    }

    [Test]
    public void DeleteProduce_ReturnsTrue_WhenDeleted()
    {
        _mockService.Setup(s => s.DeleteProduce(1)).Returns(true);

        var result = _controller.DeleteProduce(1);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.DeleteProduce(1), Times.Once);
        //check result type
        Assert.IsInstanceOf<NoContentResult>(result);
        
    }

    [Test]
    public void DeleteProduce_ReturnsFalse_WhenNotFound()
    {
        _mockService.Setup(s => s.DeleteProduce(99)).Returns(false);

        var result = _controller.DeleteProduce(99);

        //check that the correct function is called
        _mockService.Verify(x => x.DeleteProduce(99), Times.Once);
        //check result type
        Assert.IsInstanceOf<NotFoundResult>(result);
       
    }

    [Test]
    public void GetProduceByUserIdAll_returnsProduce()
    {
        //Arrange
        var parameter = 1;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter).ToList();
        _mockService.Setup(s => s.GetProduceByUserIdAll(parameter)).Returns(expectedProduce);
        
        foreach (Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //Act
        var result = _controller.GetProduceByUserIdAll(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceByUserIdAll(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as List<Produce>;
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(resultPayload, Is.EquivalentTo(expectedProduce));

    }

    [Test]
    public void GetProduceByUserId_returnsProduceOnSale()
    {
        //ARRANGE
        var parameter = 1;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter && p.IsOnSale == true).ToList();
        _mockService.Setup(s => s.GetProduceByUserId(parameter)).Returns(expectedProduce);

        foreach (Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //ACT
        var result = _controller.GetProduceByUserId(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceByUserId(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as List<Produce>;
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(resultPayload, Is.EquivalentTo(expectedProduce));
    }

    [Test]
    public void GetProduceByUserId_returnsNotFoundWhenNoUser()
    {
        //ARRANGE
        var parameter = 0;
        var produceList = DummyProduce.DummyProduceList;
        List<Produce>? expectedProduce = null;
        var user = produceList.FirstOrDefault(p => p.UserId == parameter);
            if(user != null){
            expectedProduce = produceList.Where(p => p.UserId == parameter && p.IsOnSale == true).ToList();
            };
        _mockService.Setup(s => s.GetProduceByUserId(parameter)).Returns(expectedProduce);

        //ACT
        var result = _controller.GetProduceByUserId(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceByUserId(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void GetProduceByUserId_returnsNotFoundWhenNoProduce()
    {
        //ARRANGE
        var parameter = 3;
        var produceList = DummyProduce.DummyProduceList;
        var expectedProduce = produceList.Where(p => p.UserId == parameter && p.IsOnSale == true).ToList();
        _mockService.Setup(s => s.GetProduceByUserId(parameter)).Returns(expectedProduce);

        foreach (Produce p in expectedProduce) Console.WriteLine(p.Name + p.ProduceId);
        //ACT
        var result = _controller.GetProduceByUserId(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetProduceByUserId(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<NoContentResult>(result);
        
    }
}