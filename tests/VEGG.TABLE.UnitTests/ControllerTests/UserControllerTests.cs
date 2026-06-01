using System;
using System.Collections.Generic;
using System.Text;

using FluentAssertions.Common;

using Microsoft.AspNetCore.Mvc;

using VEGG.TABLE.UnitTests.Resources;

using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
//I dont know why but this page will not wrok without this line as it stops recognising the User class and gets confused between a system class.
using User = VEGG.TABLE.Core.Entities.User;

namespace VEGG.TABLE.UnitTests.Services;

public class UserControllerTests
{
    private Mock<IUserService> _mockService = null!;
    private UserController _controller = null!;

    private static List<User> testUsers = new List<User> { };
    private static List<User> testUsers2 = new List<User> { };


    [SetUp]

    public void Setup()
    {
        _mockService = new Mock<IUserService>();
        _controller = new UserController(_mockService.Object);

        testUsers = DummyUsers.testUsers;
        testUsers2 = DummyUsers.testUsers2;

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
        var resultPayload = resultObject?.Value as List<User>;
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
        User? targetUser = users.FirstOrDefault(x => x.Id == parameter);
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
        var resultPayload = resultObject?.Value as User;
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
        User? targetUser = users.FirstOrDefault(x => x.Id == parameter);
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
            User? targetUser = changedUsers.FirstOrDefault(x => x.Id == parameter);
            if (targetUser != null)
            {
                changedUsers.Remove(targetUser);
            }

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
    [Test]
    public void AddUser_Ok()
    {
        // Arrange
        UserDTO userDTO = new UserDTO
        {
            Name = "Dylan",
            Email = "Dylan@regex",
            UserType = UserType.Buyer,
            Password = "password"
        };
        var users = testUsers;

        int currentMaxId = users.Max(x => x.Id);
        int newId = currentMaxId + 1;

        User newUser = new User
        {
            Id = newId,
            Email = userDTO.Email,
            Name = userDTO.Name,
            Password = userDTO.Password,
            UserType = userDTO.UserType,
        };
        _mockService.Setup(r => r.AddUser(userDTO)).Returns(newUser);
        users.Add(newUser);

        foreach (User user in users) { Console.WriteLine(user.Name); }

        // Act
        var result = _controller.AddUser(userDTO);

        foreach (User user in users) { Console.WriteLine(user.Name); }

        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.AddUser(userDTO), Times.Once);
        //check result type
        Assert.IsInstanceOf<CreatedAtActionResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as CreatedAtActionResult;
        var resultPayload = resultObject?.Value as User;
        Assert.IsInstanceOf<User>(resultPayload);
        //check the data is matching expected
        Assert.That(resultPayload, Is.EqualTo(newUser));
        //Assert.That(users, Is.EquivalentTo(expectedUsers))
    }
    [Test]
    public void UpdateUser_Ok()
    {
        // Arrange
        int parameterId = 1;
        var users = testUsers;
        var expectedUsers = testUsers2;
        UserDTO userDTO = new UserDTO
        {
            Name = "Dylan",
            Email = "Dylan@regex",
            UserType = UserType.Buyer,
            Password = "password"
        };
        User newUser = new User
        {
            Id = parameterId,
            Email = userDTO.Email,
            Name = userDTO.Name,
            Password = userDTO.Password,
            UserType = userDTO.UserType,
        };

        foreach (User user in users) { Console.WriteLine(user.Name); }

        _mockService.Setup(r => r.UpdateUser(parameterId, userDTO)).Returns(newUser);

        // Act
        var result = _controller.UpdateUser(parameterId, userDTO);
        foreach (User user in users) { Console.WriteLine(user.Name); }
        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.UpdateUser(parameterId, userDTO), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as User;
        Assert.IsInstanceOf<User>(resultPayload);
        //check the data is matching expected
        Assert.That(resultPayload, Is.EqualTo(newUser));
        //Assert.That(users, Is.EquivalentTo(expectedUsers));
    }

    [Test]
    public void UpdateUserName_Ok()
    {
        // Arrange
        int parameterId = 1;
        var users = testUsers;
        string parameterString = "Nicheal Bluth";

        foreach (User user in users) { Console.WriteLine(user.Name); }

        User? newUser = users.FirstOrDefault(x => x.Id == parameterId);
        if (newUser != null)
        {
            newUser.Name = parameterString;
        }

        _mockService.Setup(r => r.UpdateUserName(parameterId, parameterString)).Returns(newUser);

        // Act
        var result = _controller.UpdateUserName(parameterId, parameterString);
        foreach (User user in users) { Console.WriteLine(user.Name); }
        //ASSERT
        //check that the correct function is called
        _mockService.Verify(x => x.UpdateUserName(parameterId, parameterString), Times.Once);
        //check result type
        Assert.IsInstanceOf<OkObjectResult>(result);
        //cast the controlleroutput as a message object in order to extract its value
        var resultObject = result as OkObjectResult;
        var resultPayload = resultObject?.Value as User;
        Assert.IsInstanceOf<User>(resultPayload);
        //check the data is matching expected
        Assert.That(resultPayload, Is.EqualTo(newUser));
        //Assert.That(users, Is.EquivalentTo(expectedUsers));
    }

}
