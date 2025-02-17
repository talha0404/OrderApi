using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;

namespace OrderApi.Controllers;

public class CategoryController : BaseApiController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllAsync();

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto categoryDto)
    {
        var result = await _categoryService.AddAsync(categoryDto);

        return HandleCreatedResult(result, nameof(GetById), new { id = result.Data?.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
    {
        var result = await _categoryService.UpdateAsync(id, categoryDto);
        return HandleNoContentResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return HandleNoContentResult(result);
    }

    [HttpGet("GetCategoriesByName")]
    public async Task<IActionResult> GetCategoriesByNameAsync(string name)
    {
        var result = await _categoryService.GetCategoriesByNameAsync(name);
        return HandleResult(result);
    }
}