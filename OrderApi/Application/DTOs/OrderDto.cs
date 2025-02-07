namespace OrderApi.Application.DTOs;

public class OrderDto 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
}