using AutoMapper;
using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public class CategoryService : BaseService<Category, CategoryDto>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILoggerService _logger;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper,
        ILoggerService logger) : base(categoryRepository, mapper, logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<CategoryDto>> GetCategoriesByNameAsync(string name)
    {
        try
        {
            _logger.LogInformation($"Getting category with name: {name}");
            var category = await _categoryRepository.GetCategoryByNameAsync(name);
            if (category == null)
                return Result<CategoryDto>.Failure("Kategori bulunamadı");

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Result<CategoryDto>.Success(categoryDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving category with name: {name}", ex);
            return Result<CategoryDto>.Failure(ex.Message);
        }
    }
}