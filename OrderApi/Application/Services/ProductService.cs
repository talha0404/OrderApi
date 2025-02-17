using AutoMapper;
using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public class ProductService : BaseService<Product, ProductDto>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILoggerService _logger;

    public ProductService(
        IProductRepository productRepository,
        IMapper mapper,
        ILoggerService logger) : base(productRepository, mapper, logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId)
    {
        try
        {
            _logger.LogInformation($"Getting products for category ID: {categoryId}");
            var products = await _productRepository.GetByCategoryIdAsync(categoryId);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Result<IEnumerable<ProductDto>>.Success(productDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving products for category ID: {categoryId}", ex);
            return Result<IEnumerable<ProductDto>>.Failure(ex.Message);
        }
    }

    public async Task<Result<ProductDto>> GetMostExpensiveProduct()
    {
        try
        {
            _logger.LogInformation("Getting most expensive product");
            var product = await _productRepository.GetMostExpensiveProduct();
            if (product == null)
                return Result<ProductDto>.Failure("Ürün bulunamadı");

            var productDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(productDto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving most expensive product", ex);
            return Result<ProductDto>.Failure(ex.Message);
        }
    }

    public async Task<Result<decimal>> GetAveragePricesElectronicsProduct()
    {
        try
        {
            _logger.LogInformation("Calculating average price for electronics products");
            var averagePrice = await _productRepository.GetAveragePricesElectronicsProduct();
            return Result<decimal>.Success(averagePrice);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calculating average price for electronics products", ex);
            return Result<decimal>.Failure(ex.Message);
        }
    }
}