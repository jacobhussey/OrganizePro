using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(City))]
public class City : EntityBase
{
    [MaxLength(50)]
    [Column("city")]
    public string CityName { get; set; } = string.Empty;

    [Range(1, 10)]
    [Column("countryId")]
    public int CountryId { get; set; }
    public Country Country { get; set; } = new();
}
