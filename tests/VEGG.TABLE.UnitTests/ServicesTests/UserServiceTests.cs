using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using VEGG.TABLE.Infrastructure.Data;
using VEGG.TABLE.Infrastructure.Services;
using VEGG.TABLE.UnitTests.Resources;

namespace VEGG.TABLE.UnitTests.Services;

public class UserServiceTests
{
    private Mock<IUserRepository> _mockRepo;
    private UserService _service;

    private static List<User> testUsers = new List<User> { };
    private static List<User> testUsers2 = new List<User> { };


    [SetUp]

    public void Setup()
    {
        _mockRepo = new Mock<IUserRepository>();
        _service = new UserService(_mockRepo.Object);

        testUsers = DummyUsers.testUsers;
        testUsers2 = DummyUsers.testUsers2;
    }

    [Test]
        public void GetAll_Ok()
        {
        // Arrange
        var users = testUsers;

        _mockRepo.Setup(repo => repo.GetAllUsers())
        .Returns(testUsers);

        // Act
        var result = _service.GetAllUsers();

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetAllUsers(), Times.Once);

        //check result type
        Assert.IsInstanceOf<List<User>>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EquivalentTo(users));
        }

    [Test]
        public void GetById_Ok()
        {
        // Arrange
        var parameter = 1;
        var users = testUsers;
        User targetUser = users.FirstOrDefault(x => x.Id == parameter);

        _mockRepo.Setup(repo => repo.GetUserById(parameter))
                 .Returns(targetUser);
        // Act
        var result = _service.GetUserById(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetUserById(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<User>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EqualTo(targetUser));
        }
    [Test]
    public void GetById_NotOk()
    {
        // Arrange
        var parameter = 0;
        var users = testUsers;
        User targetUser = users.FirstOrDefault(x => x.Id == parameter);

        _mockRepo.Setup(repo => repo.GetUserById(parameter))
                 .Returns(targetUser);
        // Act
        var result = _service.GetUserById(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetUserById(parameter), Times.Once);
        //check the data is matching expected
        Assert.IsNull(result);
        Assert.That(result, Is.EqualTo(targetUser));
    }

    [Test]
        public void Delete_Ok()
        {
            // Arrange
            var parameter = 2;
            var changedUsers = testUsers;
            User targetUser = changedUsers.FirstOrDefault(x => x.Id == parameter);
            changedUsers.Remove(targetUser);
                foreach (var user in changedUsers)
                {
                    Console.WriteLine(user.Name);
                }

            var mockTuple = (true, changedUsers);
            _mockRepo.Setup(repo => repo.DeleteUser(parameter)).Returns(mockTuple);

            // Act
            var result = _service.DeleteUser(parameter);

            //ASSERT
            //check that the correct function is called
            _mockRepo.Verify(x => x.DeleteUser(parameter), Times.Once);
            //check result type
            Assert.IsInstanceOf<bool>(result.Item1);
            Assert.IsInstanceOf<List<User>>(result.Item2);
            //check the data is matching expected
            Assert.That(result, Is.EqualTo(mockTuple));
            Assert.That(result.Item1, Is.EqualTo(true));
            Assert.That(result.Item2, Is.EqualTo(changedUsers));
                foreach (var userResult in result.Item2)
                {
                    Console.WriteLine(userResult.Name);
                }
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
            _mockRepo.Setup(r => r.AddUser(userDTO)).Returns(newUser);
            users.Add(newUser);

        foreach (User user in users) { Console.WriteLine(user.Name); }

            // Act
            var result = _service.AddUser(userDTO);

        foreach (User user in users) { Console.WriteLine(user.Name); }

            //ASSERT
            //check that the correct function is called
            _mockRepo.Verify(x => x.AddUser(userDTO), Times.Once);
            //check result type
            Assert.IsInstanceOf<User>(result);
            //check the data is matching expected
            Assert.That(result, Is.EqualTo(newUser));
    }

    [Test]
    public void UpdateUser_Ok()
    {
        // Arrange
        int parameterId = 1;
        var users = testUsers;
        var expecetedUsers = testUsers2;
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

        _mockRepo.Setup(r => r.UpdateUser(parameterId, userDTO)).Returns(newUser);
     
        // Act
        var result = _service.UpdateUser(parameterId, userDTO);
        foreach (User user in users) { Console.WriteLine(user.Name); }
        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.UpdateUser(parameterId, userDTO), Times.Once);
        //check result type
        Assert.IsInstanceOf<User>(result);
        //check the data is matching expected
        Assert.That(result, Is.EqualTo(newUser));
        //Assert.That(users, Is.EquivalentTo(expecetedUsers));
    }
}
