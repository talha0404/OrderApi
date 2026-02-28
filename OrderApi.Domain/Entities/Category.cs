namespace OrderApi.Domain.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; } // Category can have more than one product
}