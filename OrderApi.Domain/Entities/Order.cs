namespace OrderApi.Domain.Entities;

public class Order: BaseEntity
{
    public int UserId { get; set; } // User FK
    public DateTime OrderDate { get; set; }
    
    public User User { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}