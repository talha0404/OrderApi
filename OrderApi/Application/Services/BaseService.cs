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
    protected readonly ILoggerService _logger;

    protected BaseService(IBaseRepository<TEntity> repository, IMapper mapper, ILoggerService logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {
        try 
        {
            _logger.LogInformation($"Getting all {typeof(TEntity).Name} records");
            var entities = await _repository.GetAllAsync();
            _logger.LogDebug($"Retrieved {entities.Count()} {typeof(TEntity).Name} records");
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving all {typeof(TEntity).Name} records", ex);
            throw;
        }
    }

    public virtual async Task<TDto?> GetByIdAsync(int id)
    {
        try 
        {
            _logger.LogInformation($"Getting {typeof(TEntity).Name} with ID: {id}");
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found");
            }
            return _mapper.Map<TDto>(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving {typeof(TEntity).Name} with ID: {id}", ex);
            throw;
        }
    }

    public virtual async Task<TDto> AddAsync(TDto dto)
    {
        try
        {
            _logger.LogInformation($"Adding new {typeof(TEntity).Name}");
            var entity = _mapper.Map<TEntity>(dto);
            var addedEntity = await _repository.AddAsync(entity);
            _logger.LogDebug($"Successfully added {typeof(TEntity).Name} with ID: {addedEntity.Id}");
            return _mapper.Map<TDto>(addedEntity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding new {typeof(TEntity).Name}", ex);
            throw;
        }
    }

    public virtual async Task<TDto> UpdateAsync(int id, TDto dto)
    {
        try
        {
            _logger.LogInformation($"Updating {typeof(TEntity).Name} with ID: {id}");
            var entity = _mapper.Map<TEntity>(dto);
            var updatedEntity = await _repository.UpdateAsync(id, entity);
            _logger.LogDebug($"Successfully updated {typeof(TEntity).Name} with ID: {id}");
            return _mapper.Map<TDto>(updatedEntity);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating {typeof(TEntity).Name} with ID: {id}", ex);
            throw;
        }
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation($"Deleting {typeof(TEntity).Name} with ID: {id}");
            var result = await _repository.DeleteAsync(id);
            if (result)
            {
                _logger.LogDebug($"Successfully deleted {typeof(TEntity).Name} with ID: {id}");
            }
            else
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found for deletion");
            }
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error deleting {typeof(TEntity).Name} with ID: {id}", ex);
            throw;
        }
    }
}