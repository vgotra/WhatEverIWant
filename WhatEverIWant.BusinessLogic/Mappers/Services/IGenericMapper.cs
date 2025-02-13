namespace WhatEverIWant.BusinessLogic.Mappers.Services;

public interface IGenericMapper<TCreate, TUpdate, TResponse, TEntity>
{
    TEntity ToEntity(TCreate createModel);
    void UpdateEntity(TUpdate updateModel, TEntity entity);
    TResponse ToResponse(TEntity entity);
}