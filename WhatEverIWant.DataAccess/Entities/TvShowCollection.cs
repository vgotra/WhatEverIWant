namespace WhatEverIWant.DataAccess.Entities;

public class TvShowCollection : EntityBase<long>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<TvShow>? Items { get; set; }
}