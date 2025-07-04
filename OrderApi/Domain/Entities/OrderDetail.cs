namespace OrderApi.Domain.Entities;

public class OrderDetail: BaseEntity
{
    public int OrderId { get; set; } // Order FK
    public int ProductId { get; set; } // Product FK
    public int Quantity { get; set; }
    
    public Order Order { get; set; } // Each Order Detail belongs to one order
    public Product Product { get; set; } // OrderDetail Should
}