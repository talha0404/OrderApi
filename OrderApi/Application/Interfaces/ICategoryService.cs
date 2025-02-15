using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface ICategoryService: IBaseService<CategoryDto>
{
    Task<CategoryDto> GetCategoriesByNameAsync(string name);
}