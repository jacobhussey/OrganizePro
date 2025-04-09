using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(User))]
public class User : EntityBase
{
    [MaxLength(50)]
    [Column("userName")]
    public string Username { get; set; } = string.Empty;

    [MaxLength(50)]
    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("active")]
    public bool IsActive { get; set; }
}

