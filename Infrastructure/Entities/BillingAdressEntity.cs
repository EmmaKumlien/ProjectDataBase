using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class BillingAdressEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string StreetName { get; set; } = null!;
    [Required]
    public int PostalCode { get; set; }
    [Required]
    [StringLength(100)]
    public string City { get; set; } = null!;

    public virtual ICollection<CustomerEntity> Customer { get; set; } = new List<CustomerEntity>();
}
