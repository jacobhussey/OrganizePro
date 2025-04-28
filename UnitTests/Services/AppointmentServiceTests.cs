using Microsoft.EntityFrameworkCore;
using OrganizePro.Context;
using OrganizePro.Models;
using OrganizePro.Services;

namespace Tests.Services;

[TestClass]
public class AppointmentServiceTests
{
    private TestDbContext _dbContext;
    private AppointmentService _service;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _dbContext = new TestDbContext(options);
        _service = new AppointmentService(_dbContext);

        _dbContext.Database.EnsureDeleted(); 
        _dbContext.Database.EnsureCreated();
    }

    [TestMethod]
    public async Task GetEntityByIdAsync_ShouldReturnAppointmentWithUserAndCustomer()
    {
        // Arrange
        var customer = new Customer { CustomerName = "John Doe" };
        var user = new User { Username = "admin" };
        var appointment = new Appointment
        {
            Title = "Meeting",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow,
            End = DateTime.UtcNow.AddHours(1)
        };

        await _dbContext.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();


        // Act
        var result = await _service.GetEntityByIdAsync(appointment.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Meeting", result.Title);
        Assert.AreEqual("John Doe", result.Customer.CustomerName);
        Assert.AreEqual("admin", result.User.Username);
    }

    [TestMethod]
    public async Task GetAllAsync_ShouldReturnAppointmentsWithUserAndCustomer()
    {
        // Arrange
        var customer = new Customer { CustomerName = "Jane Smith" };
        var user = new User { Username = "user123" };
        var appointment = new Appointment
        {
            Title = "Consultation",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow,
            End = DateTime.UtcNow.AddHours(2)
        };

        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.Users.AddAsync(user);
        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Consultation", result[0].Title);
    }

    [TestMethod]
    public async Task CreateAppointmentTableDto_ShouldReturnOrderedAppointments()
    {
        // Arrange
        var customer = new Customer { CustomerName = "Alice" };
        var user = new User { Username = "alice123" };
        var earlyAppointment = new Appointment
        {
            Title = "Early Meeting",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow.AddHours(-2),
            End = DateTime.UtcNow.AddHours(-1)
        };
        var lateAppointment = new Appointment
        {
            Title = "Late Meeting",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow.AddHours(1),
            End = DateTime.UtcNow.AddHours(2)
        };

        await _dbContext.AddAsync(earlyAppointment);
        await _dbContext.AddAsync(lateAppointment);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateAppointmentTableDto();

        // Assert
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Early Meeting", result[0].Title);
        Assert.AreEqual("Late Meeting", result[^1].Title);
    }

    [TestMethod]
    public async Task CreateCalendarAppointmentTableDto_ShouldReturnAppointmentsForGivenDate()
    {
        // Arrange
        var customer = new Customer { CustomerName = "Bob" };
        var user = new User { Username = "bob123" };
        var appointmentOnDate = new Appointment
        {
            Title = "Team Lunch",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow.Date.AddHours(12),
            End = DateTime.UtcNow.Date.AddHours(14)
        };
        var appointmentOnDifferentDate = new Appointment
        {
            Title = "Project Kickoff",
            Customer = customer,
            User = user,
            Start = DateTime.UtcNow.Date.AddDays(1).AddHours(9),
            End = DateTime.UtcNow.Date.AddDays(1).AddHours(10)
        };

        await _dbContext.AddAsync(appointmentOnDate);
        await _dbContext.AddAsync(appointmentOnDifferentDate);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _service.CreateCalendarAppointmentTableDto(DateTime.UtcNow.Date);

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Team Lunch", result[0].Title);
    }
}
