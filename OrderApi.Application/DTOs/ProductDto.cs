namespace OrderApi.Application.DTOs;

public class ProductDto: BaseEntityDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}