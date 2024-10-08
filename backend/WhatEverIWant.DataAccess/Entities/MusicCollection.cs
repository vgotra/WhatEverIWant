namespace WhatEverIWant.DataAccess.Entities;

public class MusicCollection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<MusicCollectionItem>? MusicCollectionItems { get; set; }
}