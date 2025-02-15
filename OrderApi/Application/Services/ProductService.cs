using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class ProductService: BaseService<Product,ProductDto>, IProductService
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

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        try
        {
            _logger.LogInformation($"Getting products for category ID: {categoryId}");
            var products = await _productRepository.GetByCategoryIdAsync(categoryId);
            _logger.LogDebug($"Retrieved {products.Count} products for category ID: {categoryId}");
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving products for category ID: {categoryId}", ex);
            throw;
        }
    }

    public async Task<ProductDto> GetMostExpensiveProduct()
    {
        try
        {
            _logger.LogInformation("Getting most expensive product");
            var product = await _productRepository.GetMostExpensiveProduct();
            if (product != null)
            {
                _logger.LogDebug($"Most expensive product found: {product.Name} with price: {product.Price}");
            }
            else
            {
                _logger.LogWarning("No products found in the system");
            }
            return _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving most expensive product", ex);
            throw;
        }
    }
    
    public async Task<decimal> GetAveragePricesElectronicsProduct()
    {
        try
        {
            _logger.LogInformation("Calculating average price for electronics products");
            var averagePrice = await _productRepository.GetAveragePricesElectronicsProduct();
            _logger.LogDebug($"Average price for electronics products: {averagePrice}");
            return _mapper.Map<decimal>(averagePrice);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calculating average price for electronics products", ex);
            throw;
        }
    }
}