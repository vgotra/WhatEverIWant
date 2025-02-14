using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Services;

// ReSharper disable once UnusedTypeParameter
public interface IGenericService<TCreate, TUpdate, TResponse, TEntity> where TEntity : class, IEntityBase<long>
{
    Task<IEnumerable<TResponse>> GetAllAsync();
    Task<TResponse?> GetByIdAsync(long id);
    Task<TResponse> CreateAsync(TCreate createModel);
    Task<bool> UpdateAsync(long id, TUpdate updateModel);
    Task<bool> DeleteAsync(long id);
}