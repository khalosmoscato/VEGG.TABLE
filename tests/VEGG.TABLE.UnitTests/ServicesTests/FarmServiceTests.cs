namespace VEGG.TABLE.UnitTests.Services;

public class FarmServiceTests
{
    private DBContext _context;
    private FarmService _farmService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DBContext(options);

        var repository = new FarmRepository(_context);
        _farmService = new FarmService(repository);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetAllFarmsAsync_WhenFarmsExist_ReturnsCorrectList()
    {
        // Arrange
        _context.Farms.Add(new Farm { Name = "Hackney City Farm" });
        _context.Farms.Add(new Farm { Name = "Spitalfields Farm" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _farmService.GetFarms();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(2));
    }
}