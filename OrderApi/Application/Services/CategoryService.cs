using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class CategoryService:BaseService<Category,CategoryDto>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper):base(categoryRepository, mapper)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<IEnumerable<CategoryDto>> GetCategoriesByNameAsync(string name)
    {
        var categories = await _categoryRepository.GetCategoryByNameAsync(name);
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
}