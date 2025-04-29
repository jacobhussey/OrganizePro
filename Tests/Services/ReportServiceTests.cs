using Microsoft.EntityFrameworkCore;
using OrganizePro.Models;
using OrganizePro.Services;
using OrganizePro.Context;

namespace Tests.Services;

[TestClass]
public class ReportServiceTests
{
    private TestDbContext _dbContext;
    private ReportService _service;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique DB per test
            .Options;

        _dbContext = new TestDbContext(options);
        _service = new ReportService(_dbContext);

        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    [TestMethod]
    public async Task CreateAppointmentTypeReportDto_ShouldReturnCorrectGroupedData()
    {
        // Arrange
        var appointments = new List<Appointment>
        {
            new() { Type = "Consultation", Start = new DateTime(2025, 1, 10) },
            new() { Type = "Meeting", Start = new DateTime(2025, 1, 15) },
            new() { Type = "Consultation", Start = new DateTime(2025, 2, 5) }
        };

        await _dbContext.AddRangeAsync(appointments);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateAppointmentTypeReportDto(2025);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("January", result[0].Month);
        Assert.AreEqual("Consultation", result[0].Type);
        Assert.AreEqual(1, result[0].Count);
    }

    [TestMethod]
    public async Task CreateUserScheduleReportDto_ShouldReturnCorrectUserData()
    {
        // Arrange
        var user = new User { Username = "testuser" };
        var customer = new Customer { CustomerName = "John Doe" };
        var appointment = new Appointment
        {
            User = user,
            Customer = customer,
            Title = "Planning Session",
            Type = "Strategy",
            Start = DateTime.UtcNow,
            End = DateTime.UtcNow.AddHours(1),
            Location = "Office",
            Contact = "123-456-7890"
        };

        await _dbContext.AddAsync(user);
        await _dbContext.AddAsync(customer);
        await _dbContext.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateUserScheduleReportDto();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("testuser", result[0].Username);
        Assert.AreEqual("Planning Session", result[0].AppointmentTitle);
        Assert.AreEqual("John Doe", result[0].CustomerName);
    }

    [TestMethod]
    public async Task CreateCustomerSummaryReportDto_ShouldReturnCorrectCustomerAggregations()
    {
        // Arrange
        var customer = new Customer { CustomerName = "Alice" };
        var appointments = new List<Appointment>
        {
            new () { Customer = customer, Type = "Consultation", Start = DateTime.UtcNow },
            new () { Customer = customer, Type = "Consultation", Start = DateTime.UtcNow },
            new () { Customer = customer, Type = "Strategy", Start = DateTime.UtcNow }
        };

        await _dbContext.AddAsync(customer);
        await _dbContext.AddRangeAsync(appointments);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateCustomerSummaryReportDto();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Alice", result[0].CustomerName);
        Assert.AreEqual(3, result[0].TotalAppointments);
        Assert.AreEqual("Consultation", result[0].MostCommonAppointmentType);
    }
}
