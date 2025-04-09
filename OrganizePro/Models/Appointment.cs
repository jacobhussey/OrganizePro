using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(Appointment))]
public class Appointment : EntityBase
{
    [Range(1, 10)]
    [Column("customerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = new();

    [Range(1, 10)]
    [Column("userId")]
    public int UserId { get; set; }
    public User User { get; set; } = new();

    [MaxLength(255)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("location")]
    public string Location { get; set; } = string.Empty;

    [Column("contact")]
    public string Contact { get; set; } = string.Empty;

    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [MaxLength(255)]
    [Column("url")]
    public string Url { get; set; } = string.Empty;

    [Column("start")]
    public DateTime Start { get; set; }

    [Column("end")]
    public DateTime End { get; set; }
}
