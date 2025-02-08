using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface ICategoryService: IBaseService<CategoryDto>
{
    Task<IEnumerable<CategoryDto>> GetCategoriesByNameAsync(string name);
}