namespace WhatEverIWant.DataAccess.Entities;

public class MovieCollection : EntityBase<long>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Movie>? Items { get; set; }
}