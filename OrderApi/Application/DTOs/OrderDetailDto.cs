namespace OrderApi.Application.DTOs;

public class OrderDetailDto: BaseEntityDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}