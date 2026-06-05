using Microsoft.AspNetCore.Mvc;

namespace VEGG.TABLE.UnitTests.Controllers;

public class FarmControllerTests
{
    private Mock<IFarmService>? _mockService;
    private FarmsController? _controller;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IFarmService>();
        _controller = new FarmsController(_mockService.Object);
    }

    [Test]
    public async Task GetFarms_WhenCalled_ReturnsOkObjectResultWithData()
    {
        // Arrange
        var farms = new List<FarmDTO> { new FarmDTO { Id = 1, Name = "Test" } };
        _mockService!.Setup(s => s.GetFarms()).ReturnsAsync(farms);

        // Act
        var actionResult = await _controller!.GetFarms();

        // Assert
        Assert.That(actionResult.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = actionResult.Result as OkObjectResult;
        Assert.That(okResult?.Value, Is.EqualTo(farms));
    }
}