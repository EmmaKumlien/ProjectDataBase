using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CustomerEntity
{
    [Key] 
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(BillingAdressEntity))]
    public int BillingAdressId { get; set; }
    public BillingAdressEntity BillingAdress { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(ContactInformationEntity))]
    public int ContactInformationId { get; set; }
    public ContactInformationEntity ContactInformation { get; set; } = null!;

    public virtual ICollection<OrderServiceEntity> Orders { get; set; } = new List<OrderServiceEntity>();
}
