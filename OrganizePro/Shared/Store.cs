using OrganizePro.Models;

namespace OrganizePro.Shared;

public class Store
{
    public Customer? ActiveCustomer { get; set; }
    public Appointment? ActiveAppointment { get; set; }
    public User LoggedInUser { get; set; }
}
