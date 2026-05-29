using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using VEGG.TABLE.Infrastructure.Data;
using VEGG.TABLE.Infrastructure.Services;

namespace VEGG.TABLE.UnitTests.Services;

public class UserServiceTests
{
        private Mock<IUserRepository> _mockRepo;
        private UserService _service;

    //Use cross-platform path formatting
    private readonly string filePath1 =
    Path.Combine(AppContext.BaseDirectory, "Resources", "users.json");
    [SetUp]

        public void Setup()
        {
            _mockRepo = new Mock<IUserRepository>();
            _service = new UserService(_mockRepo.Object);
        }

    [Test]
        public void GetAll_Ok()
        {
        // Arrange
        var users = Utils.GetFileContent<User>(filePath1);


        _mockRepo.Setup(repo => repo.GetAllUsers())
        .Returns(users);

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
        var users = Utils.GetFileContent<User>(filePath1);
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
    public void Delete_Ok()
    {
        // Arrange
        var parameter = 1;
        var initialUsers = Utils.GetFileContent<User>(filePath1);
        User targetUser = initialUsers.FirstOrDefault(x => x.Id == parameter);
        var ChangedUsers = initialUsers.Remove(targetUser);

        _mockRepo.Setup(repo => repo.DeleteUser(parameter))
                 .Returns(ChangedUsers);

        // Act
        var result = _service.DeleteUser(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.DeleteUser(parameter), Times.Once);
        //check result type
        Assert.IsInstanceOf<bool>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EqualTo(ChangedUsers));
    }
}
