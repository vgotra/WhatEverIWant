namespace WhatEverIWant.DataAccess.Entities;

public class MusicCollection : EntityBase<long>
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public ICollection<Music>? Items { get; set; }
}