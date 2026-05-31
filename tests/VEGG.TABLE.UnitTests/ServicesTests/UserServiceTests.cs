using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using VEGG.TABLE.Infrastructure.Data;
using VEGG.TABLE.Infrastructure.Services;

namespace VEGG.TABLE.UnitTests.Services;

public class UserServiceTests
{
    private Mock<IUserRepository> _mockRepo;
    private UserService _service;

    private static List<User> testUsers = new List<User> { };

    //Use cross-platform path formatting
    //private readonly string filePath1 =
    //Path.Combine(AppContext.BaseDirectory, "Resources", "users.json");

    [SetUp]

    public void Setup()
    {
        _mockRepo = new Mock<IUserRepository>();
        _service = new UserService(_mockRepo.Object);

        testUsers =

        //Utils.GetFileContent<User>(filePath1);

        new List<User> {
                            new User
                            {
                                Id = 1,
                                Name = "VegManDan",
                                Email = "bossman@live.co.uk",
                                Password = "highthere",
                                UserType = UserType.Buyer
                            },
                             new User
                            {
                                Id = 2,
                                Name = "VegManDan2",
                                Email = "bossman2@live.co.uk",
                                Password = "highthere2",
                                UserType = UserType.Buyer
                            }
                        };

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
}
