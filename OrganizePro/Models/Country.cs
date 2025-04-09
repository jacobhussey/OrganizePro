using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(Country))]
public class Country : EntityBase
{
    [MaxLength(50)]
    [Column("country")]
    public string CountryName { get; set; } = string.Empty;
}
