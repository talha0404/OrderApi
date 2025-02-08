using AutoMapper;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public abstract class BaseService<TEntity, TDto>: IBaseService<TDto> 
    where TEntity : BaseEntity 
    where TDto : class
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    protected BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public virtual async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public virtual async Task<TDto> AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var addedEntity = await _repository.AddAsync(entity);
        return _mapper.Map<TDto>(addedEntity);
    }

    public virtual async Task<TDto> UpdateAsync(int id, TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        var updatedEntity = await _repository.UpdateAsync(id, entity);
        return _mapper.Map<TDto>(updatedEntity);
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}