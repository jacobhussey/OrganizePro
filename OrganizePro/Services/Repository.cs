using OrganizePro.Models;

namespace OrganizePro.Services;

public class Repository
{
    public Customer? ActiveCustomer { get; set; }
    public Appointment? ActiveAppointment { get; set; }
    public User LoggedInUser { get; set; }
}
