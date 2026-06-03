using Microsoft.Extensions.Configuration;

namespace VEGG.TABLE.UnitTests.Services;

[TestFixture]
public class AuthServiceTests
{
    private Mock<IUserRepository> _mockRepo = null!;
    private Mock<IConfiguration> _mockConfig = null!;
    private AuthService _authService = null!;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IUserRepository>();
        _mockConfig = new Mock<IConfiguration>();

        // Mock the configuration values that GenerateJwtToken accesses
        _mockConfig.Setup(c => c["Jwt:Key"]).Returns("YourSuperSecretKeyMustBeAtLeast16CharactersLong");
        _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
        _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");

        _authService = new AuthService(_mockRepo.Object, _mockConfig.Object);
    }

    [Test]
    public void Authenticate_ValidCredentials_ReturnsUserDtoWithToken()
    {
        var user = new User
        {
            Id = 1,
            Email = "test@test.com",
            Password = BCrypt.Net.BCrypt.HashPassword("testpw"),
            Name = "Test",
            UserType = UserType.Buyer
        };
        _mockRepo.Setup(repo => repo.GetByEmail("test@test.com")).Returns(user);

        var result = _authService.Authenticate("test@test.com", "testpw");

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Email, Is.EqualTo("test@test.com"));
            Assert.That(result!.Token, Is.Not.Null.And.Not.Empty); // Verify token is generated
        });
    }

    [Test]
    public void Authenticate_InvalidPassword_ReturnsNull()
    {
        var user = new User
        {
            Email = "test@test.com",
            Password = BCrypt.Net.BCrypt.HashPassword("testpw"),
            Name = "Test"
        };
        _mockRepo.Setup(repo => repo.GetByEmail("test@test.com")).Returns(user);

        var result = _authService.Authenticate("test@test.com", "wrongpassword");

        Assert.That(result, Is.Null);
    }
}