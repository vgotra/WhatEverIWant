namespace WhatEverIWant.DataAccess.Entities;

public class SeriesCollection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<SeriesCollectionItem>? SeriesCollectionItems { get; set; }
}