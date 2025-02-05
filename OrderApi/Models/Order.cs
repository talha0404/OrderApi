namespace OrderApi.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; } // User FK
    public DateTime OrderDate { get; set; }
    
    public User User { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}