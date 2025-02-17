using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface ICategoryService : IBaseService<CategoryDto>
{
    Task<Result<CategoryDto>> GetCategoriesByNameAsync(string name);
}