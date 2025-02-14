using Microsoft.EntityFrameworkCore;
using WhatEverIWant.BusinessLogic.Mappers.Services;
using WhatEverIWant.DataAccess;

namespace WhatEverIWant.BusinessLogic.Services;

public class GenericService<TCreate, TUpdate, TResponse, TEntity> : IGenericService<TCreate, TUpdate, TResponse, TEntity>
    where TEntity : class
{
    
    private readonly DbSet<TEntity> _dbSet;
    private readonly ApplicationDbContext _dbContext;
    private readonly IGenericMapper<TCreate, TUpdate, TResponse, TEntity> _mapper;

    protected GenericService(ApplicationDbContext dbContext, IGenericMapper<TCreate, TUpdate, TResponse, TEntity> mapper)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        
        _dbContext = dbContext;
        _mapper = mapper;
        
        _dbSet = dbContext.Set<TEntity>();
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