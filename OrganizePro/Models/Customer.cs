using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizePro.Models;

[Table(nameof(Customer))]
public class Customer : EntityBase
{
    [MaxLength(45)]
    [Column("customerName")]
    public string CustomerName { get; set; } = string.Empty;

    [Range(1, 10)]
    [Column("addressId")]
    public int AddressId { get; set; }
    public Address Address { get; set; } = new(); 

    [Column("active")]
    public bool IsActive { get; set; }
}
