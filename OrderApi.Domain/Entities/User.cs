namespace OrderApi.Domain.Entities;

public class User: BaseEntity
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}