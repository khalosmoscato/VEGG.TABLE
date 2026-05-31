using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Mvc;

using VEGG.TABLE.UnitTests.Resources;

//I dont know why but this page will not wrok without this line as it stops recognising the User class and gets confused between a system class.
using User = VEGG.TABLE.Core.Entities.User;


using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace VEGG.TABLE.UnitTests.Services;

public class UserControllerTests
{
    private Mock<IUserService> _mockService;
    private UserController _controller;

    private static List<User> testUsers = new List<User> { };

    [SetUp]

    public void Setup()
    {
        _mockService = new Mock<IUserService>();
        _controller = new UserController(_mockService.Object);

        testUsers = DummyUsers.testUsers;
    }
        
    [Test]
        public void GetAll_Ok()
        {
        // Arrange
        var users = testUsers;

        _mockService.Setup(s => s.GetAllUsers())
        .Returns(testUsers);

        // Act
        var result = _controller.GetAllUsers();

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetAllUsers(), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject.Value as List<User>;
        Assert.IsInstanceOf<List<User>>(resultPayload);
        //check the data is matching expected
        Assert.That(resultPayload, Is.EquivalentTo(users));
        }

    [Test]
        public void GetById_Ok()
        {
        // Arrange
        var parameter = 1;
        var users = testUsers;
        User targetUser = users.FirstOrDefault(x => x.Id == parameter);
        _mockService.Setup(s => s.GetUserById(parameter)).Returns(targetUser);

        // Act
        var result = _controller.GetUserById(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetUserById(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject.Value as User;
        Assert.IsInstanceOf<User>(resultPayload);
        //check the data is matching expected
        Assert.That(resultPayload, Is.EqualTo(targetUser));
        }

    [Test]
    public void GetById_NotOk()
    {
        // Arrange
        var parameter = 0;
        var users = testUsers;
        User targetUser = users.FirstOrDefault(x => x.Id == parameter);
        _mockService.Setup(s => s.GetUserById(parameter)).Returns(targetUser);

        // Act
        var result = _controller.GetUserById(parameter);

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.GetUserById(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
    [Test]
        public void Delete_Ok()
        {
            // Arrange
            int parameter = 2;
            List<User> changedUsers = testUsers;
            User targetUser = changedUsers.FirstOrDefault(x => x.Id == parameter);
            changedUsers.Remove(targetUser);

            var mockTuple = (true, changedUsers);
            _mockService.Setup(repo => repo.DeleteUser(parameter)).Returns(mockTuple);

            // Act
            var result = _controller.DeleteUser(parameter);

            //ASSERT
            //check that the correct function is called
            _mockService.Verify(x => x.DeleteUser(parameter), Times.Once);
            //check result type
            Assert.IsInstanceOf<NoContentResult>(result);  
            //cast the controlleroutput as a message object in order to extract its value
        }
}
