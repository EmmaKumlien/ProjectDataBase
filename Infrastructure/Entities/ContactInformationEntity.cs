using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

[Index(nameof(Email), IsUnique = true)]
public class ContactInformationEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public string Email { get; set; }=null!;


}
