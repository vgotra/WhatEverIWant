namespace WhatEverIWant.DataAccess.Entities;

public class AudioBookCollection : EntityBase<long>
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public ICollection<AudioBook>? Items { get; set; }
}