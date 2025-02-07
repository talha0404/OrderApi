namespace OrderApi.Domain.Entities;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}