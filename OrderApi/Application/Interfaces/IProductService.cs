using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface IProductService: IBaseService<ProductDto>
{
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    Task<ProductDto> GetMostExpensiveProduct();

    Task<decimal> GetAveragePricesElectronicsProduct();
}