using System.ComponentModel.DataAnnotations;

namespace OrganizePro.DTOs;

public class CustomerTableDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string CityName { get; set; }
    public string PostalCode { get; set; }
    public string CountryName { get; set; }
    public string Phone { get; set; }
}

