namespace Infrastructure.Dtos;

public class ProductDTO
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }= null!;
    public string ManufacturerName { get; set; } = null!;
}
