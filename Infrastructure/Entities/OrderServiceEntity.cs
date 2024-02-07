using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class OrderServiceEntity
{
    [Key] 
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    

    [Required]
    [ForeignKey(nameof(CustomerEntity))]
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;


    public virtual ICollection<OrderRowsEntity> OrderRows { get; set; } = new List<OrderRowsEntity>();
    
}
