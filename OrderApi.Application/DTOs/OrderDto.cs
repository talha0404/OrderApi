namespace OrderApi.Application.DTOs;

public class OrderDto: BaseEntityDto
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
}