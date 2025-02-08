using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class ProductService: BaseService<Product,ProductDto>, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _productRepository.GetByCategoryIdAsync(categoryId);
        return _mapper.Map<IEnumerable<ProductDto>>(new Product());
    }
}