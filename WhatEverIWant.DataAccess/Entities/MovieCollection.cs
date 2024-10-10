namespace WhatEverIWant.DataAccess.Entities;

public class MovieCollection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<MovieCollectionItem>? MovieCollectionItems { get; set; }
}