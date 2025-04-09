namespace OrganizePro.DTOs;

public class UserScheduleReportDto
{
    public string Username { get; set; }
    public string CustomerName { get; set; }
    public string AppointmentTitle { get; set; }
    public string AppointmentType { get; set; }
    public string Location { get; set; }
    public string Contact { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}