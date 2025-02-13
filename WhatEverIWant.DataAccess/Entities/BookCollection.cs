namespace WhatEverIWant.DataAccess.Entities;

public class BookCollection : EntityBase<long>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Book>? Items { get; set; }
}