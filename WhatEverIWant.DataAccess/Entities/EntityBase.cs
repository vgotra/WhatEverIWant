namespace WhatEverIWant.DataAccess.Entities;

public class EntityBase<T> : IEntityBase<T> where T : struct
{
    /// <summary>Snowflake id of the entity</summary>
    public T Id { get; set; }
}