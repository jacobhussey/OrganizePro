using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(Address))]
public class Address : EntityBase
{
    [MaxLength(50)]
    [Column("address")]
    public string AddressLine1 { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("address2")]
    public string AddressLine2 { get; set; } = string.Empty;

    [Range(1, 10)]
    [Column("cityId")]
    public int CityId { get; set; }
    public City City { get; set; } = new();

    [MaxLength(10)]
    [Column("postalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [MaxLength(20)]
    [Column("phone")]
    public string Phone { get; set; } = string.Empty;
}
