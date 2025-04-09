namespace OrganizePro.DTOs;

public class CustomerSummaryReportDto
{
    public string CustomerName { get; set; }
    public int TotalAppointments { get; set; }
    public string MostCommonAppointmentType { get; set; }
}