namespace WhatEverIWant.DataAccess.Repositories;

public class GenericRepository<TEntity>(ApplicationDbContext context)
    : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext Context = context;
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSet.ToListAsync();

    public virtual async ValueTask<TEntity?> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();

    public virtual async Task AddAsync(TEntity entity) => await DbSet.AddAsync(entity);

    public virtual void Update(TEntity entity) => DbSet.Update(entity);

    public virtual void Remove(TEntity entity) => DbSet.Remove(entity);
}