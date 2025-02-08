using OrderApi.Domain.Entities;

namespace OrderApi.Domain.Interfaces;

public interface ICategoryRepository: IBaseRepository<Category>
{
    Task<Category?> GetCategoryByNameAsync(string name);
}