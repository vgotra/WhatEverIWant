using Microsoft.EntityFrameworkCore;
using WhatEverIWant.BusinessLogic.Mappers.Services;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Services;

public class GenericService<TCreate, TUpdate, TResponse, TEntity> : IGenericService<TCreate, TUpdate, TResponse, TEntity>
    where TEntity : class, IEntityBase<long>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IGenericMapper<TCreate, TUpdate, TResponse, TEntity> _mapper;
    private readonly DbSet<TEntity> _dbSet;
    private readonly ISnowflakeIdGenerator _idGenerator;

    protected GenericService(ApplicationDbContext dbContext, IGenericMapper<TCreate, TUpdate, TResponse, TEntity> mapper, ISnowflakeIdGenerator idGenerator)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        
        _dbContext = dbContext;
        _mapper = mapper;
        _dbSet = dbContext.Set<TEntity>();
        _idGenerator = idGenerator;
    }

    public async Task<IEnumerable<TResponse>> GetAllAsync()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        return entities.Select(entity => _mapper.ToResponse(entity));
    }

    public async Task<TResponse?> GetByIdAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null ? _mapper.ToResponse(entity) : default;
    }

    public async Task<TResponse> CreateAsync(TCreate createModel)
    {
        var entity = _mapper.ToEntity(createModel);
        entity.Id = _idGenerator.NextId();
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.ToResponse(entity);
    }

    public async Task<bool> UpdateAsync(long id, TUpdate updateModel)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return false;

        _mapper.UpdateEntity(updateModel, entity);
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}