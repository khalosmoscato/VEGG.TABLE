using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

using RecordShop.Repository;

namespace VEGG.TABLE.UnitTests.Services;

public class UserServiceTests
{
        private Mock<IUserRepository> _mockRepo;
        private UserService _service;

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
        var users = Utils.GetFileContent<User>("tests\\VEGG.TABLE.UnitTest\\Resources\\Users.JSON");

        _mockRepo.Setup(repo => repo.GetAll())
        .Returns(users);

        // Act
        var result = _service.GetAll();

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetAll(), Times.Once);
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
        var users = Utils.GetFileContent<User>("tests\\VEGG.TABLE.UnitTest\\Resources\\Users.JSON");
        User targetUser = users.FirstOrDefault(x => x.Id == parameter);

            _mockRepo.Setup(repo => repo.GetById(parameter))
                     .Returns(targetUser);

            // Act
            var result = _service.GetById(parameter);

        //ASSERT
        //check that the correct function is called
        _mockRepo.Verify(x => x.GetById(), Times.Once);
        //check result type
        Assert.IsInstanceOf<User>(result);
        //check the data is matching expected
        Assert.IsNotNull(result);
        Assert.That(result, Is.EqualTo(targetUser));

        
    }
}
