using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;

namespace OrderApi.Controllers;

public class ProductController : BaseApiController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllAsync();
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        var result = await _productService.AddAsync(productDto);
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Data.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDto productDto)
    {
        var result = await _productService.UpdateAsync(id, productDto);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteAsync(id);
        return HandleNoContentResult(result);
    }

    [HttpGet("GetProductsSpecificCategory/{categoryId}")]
    public async Task<IActionResult> GetProductsSpecificCategory(int categoryId)
    {
        var result = await _productService.GetProductsByCategoryAsync(categoryId);
        return HandleResult(result);
    }

    [HttpGet("GetMostExpensiveProduct")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var result = await _productService.GetMostExpensiveProduct();
        return HandleResult(result);
    }

    [HttpGet("GetAveragePricesElectronicsProduct")]
    public async Task<IActionResult> GetAveragePricesElectronicsProduct()
    {
        var result = await _productService.GetAveragePricesElectronicsProduct();
        return HandleResult(result);
    }
}