namespace WhatEverIWant.Services;

public interface IGenericService<TCreate, TUpdate, TResponse, TEntity> where TEntity : class
{
    Task<IEnumerable<TResponse>> GetAllAsync();
    Task<TResponse?> GetByIdAsync(Guid id);
    Task<TResponse> CreateAsync(TCreate createModel);
    Task<bool> UpdateAsync(Guid id, TUpdate updateModel);
    Task<bool> DeleteAsync(Guid id);
}