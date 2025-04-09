namespace OrganizePro.DTOs;

public class AppointmentTableDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CustomerName { get; set; }
    public string Username { get;set;}
    public string Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Location { get; set; }
    public string Contact { get; set; }
}
