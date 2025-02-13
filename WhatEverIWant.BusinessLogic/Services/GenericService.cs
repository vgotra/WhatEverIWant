using WhatEverIWant.BusinessLogic.Mappers.Services;

namespace WhatEverIWant.BusinessLogic.Services;

public class GenericService<TCreate, TUpdate, TResponse, TEntity> : IGenericService<TCreate, TUpdate, TResponse, TEntity>
    where TEntity : class
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly IGenericMapper<TCreate, TUpdate, TResponse, TEntity> _mapper;

    public GenericService(IGenericRepository<TEntity> repository, IGenericMapper<TCreate, TUpdate, TResponse, TEntity> mapper)
    {
        ArgumentNullException.ThrowIfNull(repository, nameof(repository));
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TResponse>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(entity => _mapper.ToResponse(entity));
    }

    public async Task<TResponse?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity != null ? _mapper.ToResponse(entity) : default;
    }

    public async Task<TResponse> CreateAsync(TCreate createModel)
    {
        var entity = _mapper.ToEntity(createModel);
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return _mapper.ToResponse(entity);
    }

    public async Task<bool> UpdateAsync(Guid id, TUpdate updateModel)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return false;

        _mapper.UpdateEntity(updateModel, entity);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return false;

        _repository.Remove(entity);
        await _repository.SaveChangesAsync();
        return true;
    }
}