using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;


namespace OrderApi.Application.Interfaces;

public interface IProductService : IBaseService<ProductDto>
{
    Task<Result<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId);
    Task<Result<ProductDto>> GetMostExpensiveProduct();
    Task<Result<decimal>> GetAveragePricesElectronicsProduct();
}