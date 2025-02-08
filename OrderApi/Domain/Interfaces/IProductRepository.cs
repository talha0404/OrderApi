using OrderApi.Domain.Entities;

namespace OrderApi.Domain.Interfaces;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<List<Product>> GetByCategoryIdAsync(int categoryId);
}