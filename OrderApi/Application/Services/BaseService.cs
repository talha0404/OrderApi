using AutoMapper;
using OrderApi.Application.Common.Result;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public abstract class BaseService<TEntity, TDto> : IBaseService<TDto>
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

    public virtual async Task<Result<IEnumerable<TDto>>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation($"Getting all {typeof(TEntity).Name} records");
            var entities = await _repository.GetAllAsync();
            _logger.LogDebug($"Retrieved {entities.Count()} {typeof(TEntity).Name} records");
            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);
            return Result<IEnumerable<TDto>>.Success(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving all {typeof(TEntity).Name} records", ex);
            return Result<IEnumerable<TDto>>.Failure(ex.Message);
        }
    }

    public virtual async Task<Result<TDto>> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation($"Getting {typeof(TEntity).Name} with ID: {id}");
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found");
                return Result<TDto>.Failure($"{typeof(TEntity).Name} bulunamadı");
            }
            var dto = _mapper.Map<TDto>(entity);
            return Result<TDto>.Success(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving {typeof(TEntity).Name} with ID: {id}", ex);
            return Result<TDto>.Failure(ex.Message);
        }
    }

    public virtual async Task<Result<TDto>> AddAsync(TDto dto)
    {
        try
        {
            _logger.LogInformation($"Adding new {typeof(TEntity).Name}");
            var entity = _mapper.Map<TEntity>(dto);
            var addedEntity = await _repository.AddAsync(entity);
            _logger.LogDebug($"Successfully added {typeof(TEntity).Name} with ID: {addedEntity.Id}");
            var addedDto = _mapper.Map<TDto>(addedEntity);
            return Result<TDto>.Success(addedDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding new {typeof(TEntity).Name}", ex);
            return Result<TDto>.Failure(ex.Message);
        }
    }

    public virtual async Task<Result<TDto>> UpdateAsync(int id, TDto dto)
    {
        try
        {
            _logger.LogInformation($"Updating {typeof(TEntity).Name} with ID: {id}");
            var entity = _mapper.Map<TEntity>(dto);
            var updatedEntity = await _repository.UpdateAsync(id, entity);
            _logger.LogDebug($"Successfully updated {typeof(TEntity).Name} with ID: {id}");
            var updatedDto = _mapper.Map<TDto>(updatedEntity);
            return Result<TDto>.Success(updatedDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating {typeof(TEntity).Name} with ID: {id}", ex);
            return Result<TDto>.Failure(ex.Message);
        }
    }

    public virtual async Task<Result<bool>> DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation($"Deleting {typeof(TEntity).Name} with ID: {id}");
            var result = await _repository.DeleteAsync(id);
            if (result)
            {
                _logger.LogDebug($"Successfully deleted {typeof(TEntity).Name} with ID: {id}");
                return Result<bool>.Success(true);
            }
            else
            {
                _logger.LogWarning($"{typeof(TEntity).Name} with ID: {id} not found for deletion");
                return Result<bool>.Failure($"{typeof(TEntity).Name} bulunamadı");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error deleting {typeof(TEntity).Name} with ID: {id}", ex);
            return Result<bool>.Failure(ex.Message);
        }
    }
}