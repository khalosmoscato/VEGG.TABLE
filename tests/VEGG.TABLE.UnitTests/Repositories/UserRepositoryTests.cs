namespace VEGG.TABLE.UnitTests.Repositories;

[TestFixture]
public class UserRepositoryTests
{
    private DBContext? _context;
    private UserRepository? _repo;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new DBContext(options);
        _repo = new UserRepository(_context);
    }

    [Test]
    public void GetByEmail_ExistingUser_ReturnsNormalizedUser()
    {
        _context.UserTable.Add(new User
        {
            Email = "test@test.com",
            Password = BCrypt.Net.BCrypt.HashPassword("testpw"),
            Name = "Test",
            UserType = UserType.Buyer
        });
        _context.SaveChanges();

        var result = _repo.GetByEmail("TEST@TEST.COM");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Email, Is.EqualTo("test@test.com"));
    }
}