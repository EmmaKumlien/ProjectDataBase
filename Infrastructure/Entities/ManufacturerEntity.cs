using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

[Index(nameof(ManufacturerName), IsUnique = true)]
public class ManufacturerEntity
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ManufacturerName { get; set; } = null!;

    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
