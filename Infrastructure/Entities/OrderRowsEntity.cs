using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class OrderRowsEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public int Quatity { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Required]
    [ForeignKey(nameof(ProductEntity))]
    public int ProductId { get; set; }
    public ProductEntity Products { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(OrderServiceEntity))]
    public int OrderId { get; set; }
    public OrderServiceEntity OrderService { get; set; } = null!;

}
