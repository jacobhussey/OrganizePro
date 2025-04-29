using Microsoft.EntityFrameworkCore;
using OrganizePro.Models;
using OrganizePro.Services;
using OrganizePro.Context;
using Microsoft.Extensions.Logging.Abstractions;

namespace Tests.Services;

[TestClass]
public class UserServiceTests
{
    private TestDbContext _dbContext;
    private UserService _service;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        _dbContext = new TestDbContext(options);
        var logger = NullLogger<UserService>.Instance;
        _service = new UserService(_dbContext, logger);

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    [TestMethod]
    public async Task ValidateLogin_ShouldReturnTrue_ForCorrectCredentials()
    {
        // Arrange
        var user = new User { Username = "testuser", Password = "secure123" };
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.ValidateLogin(new User { Username = "testuser", Password = "secure123" });

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task ValidateLogin_ShouldReturnFalse_ForIncorrectPassword()
    {
        // Arrange
        var user = new User { Username = "testuser", Password = "secure123" };
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.ValidateLogin(new User { Username = "testuser", Password = "wrongpass" });

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task ValidateLogin_ShouldReturnFalse_ForNonExistentUser()
    {
        // Act
        var result = await _service.ValidateLogin(new User { Username = "unknown", Password = "password" });

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task ValidateCreate_ShouldReturnTrue_ForUniqueUsername()
    {
        // Act
        var result = await _service.ValidateCreate(new User { Username = "newuser" });

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task ValidateCreate_ShouldReturnFalse_ForDuplicateUsername()
    {
        // Arrange
        var existingUser = new User { Username = "duplicateUser" };
        await _dbContext.AddAsync(existingUser);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.ValidateCreate(new User { Username = "duplicateUser" });

        // Assert
        Assert.IsFalse(result);
    }
}
