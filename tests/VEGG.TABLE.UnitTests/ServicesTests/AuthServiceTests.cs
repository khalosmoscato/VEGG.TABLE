namespace VEGG.TABLE.UnitTests.Services;

[TestFixture]
public class AuthServiceTests
{
    private Mock<IUserRepository> _mockRepo;
    private AuthService _authService;

    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IUserRepository>();
        _authService = new AuthService(_mockRepo.Object);
    }

    [Test]
    public void Authenticate_ValidCredentials_ReturnsUserDto()
    {
        var user = new User 
        {
            Email = "test@test.com", 
            Password = BCrypt.Net.BCrypt.HashPassword("testpw"), 
            Name = "Test", 
            UserType = UserType.Buyer 
        };
        _mockRepo.Setup(repo => repo.GetByEmail("test@test.com")).Returns(user);

        var result = _authService.Authenticate("test@test.com", "testpw");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Email, Is.EqualTo("test@test.com"));
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
