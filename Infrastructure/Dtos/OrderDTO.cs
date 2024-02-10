using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class OrderDTO
{

    public int Id { get; set; }
    public int Quatity { get; set; }
    public decimal Price { get; set; }
    public CustomerDTO Customer { get; set; } = null!;
    public ProductDTO Product { get; set; } = null!;


}
