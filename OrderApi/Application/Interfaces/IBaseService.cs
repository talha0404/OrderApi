using OrderApi.Application.Common.Result;

namespace OrderApi.Application.Interfaces;

public interface IBaseService<TDto>
{
    Task<Result<IEnumerable<TDto>>> GetAllAsync();
    Task<Result<TDto>> GetByIdAsync(int id);
    Task<Result<TDto>> AddAsync(TDto dto);
    Task<Result<TDto>> UpdateAsync(int id, TDto dto);
    Task<Result<bool>> DeleteAsync(int id);
}
