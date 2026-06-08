using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.UnitTests.Repositories;

public class FarmRepositoryTests
{
    private DBContext? _context;
    private FarmRepository? _repository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new DBContext(options);
        _repository = new FarmRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context!.Dispose();
    }

    [Test]
    public async Task GetAllFarms_ShouldReturnAllFarms()
    {
        // Arrange
        var owner = new User { Name = "TestUser", Email = "test@test.com", Password = "pw" };
        _context!.Farms.Add(new Farm { Name = "Hackney City Farm", Owner = owner });
        _context.Farms.Add(new Farm { Name = "Spitalfields Farm", Owner = owner });
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository!.GetFarms();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.First().OwnerName, Is.EqualTo("TestUser"));
    }
}