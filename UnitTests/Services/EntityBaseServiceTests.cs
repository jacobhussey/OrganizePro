using Microsoft.EntityFrameworkCore;
using OrganizePro.Context;
using Tests.Models;

namespace Tests.Services;

[TestClass]
public class EntityBaseServiceTests
{
    private TestDbContext _dbContext;
    private TestEntityService _service;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        _dbContext = new TestDbContext(options);
        _service = new TestEntityService(_dbContext);

        _dbContext.Database.EnsureDeleted(); 
        _dbContext.Database.EnsureCreated(); 
    }

    [TestMethod]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoEntitiesExist()
    {
        // Arrange (Nothing to set up)

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public async Task CreateEntity_ShouldAddEntityToDatabase()
    {
        // Arrange
        var entity = new TestEntity { Name = "Test" };

        // Act
        await _service.CreateEntity(entity);
        var result = await _service.GetEntityByIdAsync(entity.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test", result.Name);
    }

    [TestMethod]
    public async Task GetEntityByIdAsync_ShouldReturnEntity_WhenEntityExists()
    {
        // Arrange
        var entity = new TestEntity { Name = "Test" };
        await _service.CreateEntity(entity);

        // Act
        var result = await _service.GetEntityByIdAsync(entity.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test", result.Name);
    }

    [TestMethod]
    public async Task UpdateEntity_ShouldModifyExistingEntity()
    {
        // Arrange
        var entity = new TestEntity { Name = "Old Name" };
        await _service.CreateEntity(entity);

        // Act
        entity.Name = "New Name";
        await _service.UpdateEntity(entity);
        var result = await _service.GetEntityByIdAsync(entity.Id);

        // Assert
        Assert.AreEqual("New Name", result.Name);
    }

    [TestMethod]
    public async Task DeleteEntity_ShouldRemoveEntityFromDatabase()
    {
        // Arrange
        var entity = new TestEntity { Name = "Test" };
        await _service.CreateEntity(entity);

        // Act
        await _service.DeleteEntity(entity);
        var result = await _service.GetEntityByIdAsync(entity.Id);

        // Assert
        Assert.IsNull(result);
    }
}
