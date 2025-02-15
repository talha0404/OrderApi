using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public class CategoryService:BaseService<Category,CategoryDto>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILoggerService _logger;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILoggerService logger): base(categoryRepository, mapper)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }
    
    public async Task<CategoryDto> GetCategoriesByNameAsync(string name)
    {
        _logger.LogInformation($"LOG: Attempting to retrieve product with name: {name}"); // Log before operation
        try
        {
            var categories = await _categoryRepository.GetCategoryByNameAsync(name);
            _logger.LogDebug($"LOG: Category retrieved successfully: {name}"); // Log detailed info
            return _mapper.Map<CategoryDto>(categories);
        }
        catch (Exception ex)
        {
            _logger.LogError($"LOG: Error retrieving product with name: {name}", ex); // Log the exception
            throw;
        }
    }
}