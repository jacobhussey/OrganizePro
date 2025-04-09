using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrganizePro.Models;

public abstract class EntityBase 
{
    [Range(1, 10)]
    public int Id { get; set; }

    [Column("createDate")]
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    [MaxLength(40)]
    [Column("createdBy")]
    public string CreatedBy { get; set; } = string.Empty;

    [Column("lastUpdate")]
    public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

    [MaxLength(40)]
    [Column("lastUpdateBy")]
    public string LastUpdateBy { get; set; } = string.Empty;
}