using Microsoft.EntityFrameworkCore;
using OrganizePro.Context;
using OrganizePro.Models;
using OrganizePro.Services;

namespace Tests.Services;

[TestClass]
public class CustomerServiceTests
{
    private TestDbContext _dbContext;
    private CustomerService _service;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new TestDbContext(options);
        _service = new CustomerService(_dbContext);

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    [TestMethod]
    public async Task GetEntityByIdAsync_ShouldReturnCustomerWithAddressCityAndCountry()
    {
        // Arrange
        var country = new Country { CountryName = "United States" };
        var city = new City { CityName = "Boise", Country = country };
        var address = new Address { AddressLine1 = "123 Sesame St", City = city };
        var customer = new Customer { CustomerName = "Somebody", Address = address };

        await _dbContext.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.GetEntityByIdAsync(customer.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("United States", result.Address.City.Country.CountryName);
        Assert.AreEqual("Boise", result.Address.City.CityName);
        Assert.AreEqual("123 Sesame St", result.Address.AddressLine1);
    }

    [TestMethod]
    public async Task CreateCustomerTableDto_ShouldReturnCorrectData()
    {
        // Arrange
        var country = new Country { Id = 1, CountryName = "USA" };
        var city = new City { Id = 1, CityName = "New York", Country = country };
        var address = new Address
        {
            Id = 1,
            AddressLine1 = "123 Main St",
            AddressLine2 = "Apt 4B",
            PostalCode = "10001",
            City = city,
            Phone = "123-456-7890"
        };
        var customer = new Customer { Id = 1, CustomerName = "John Doe", Address = address };

        await _dbContext.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateCustomerTableDto();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("John Doe", result[0].CustomerName);
        Assert.AreEqual("123 Main St", result[0].AddressLine1);
        Assert.AreEqual("Apt 4B", result[0].AddressLine2);
        Assert.AreEqual("New York", result[0].CityName);
        Assert.AreEqual("10001", result[0].PostalCode);
        Assert.AreEqual("USA", result[0].CountryName);
        Assert.AreEqual("123-456-7890", result[0].Phone);
    }
}