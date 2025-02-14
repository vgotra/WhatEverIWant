namespace WhatEverIWant.DataAccess.Entities;

public class Book : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? Isbn { get; set; }
    public int? Year { get; set; }

    public ICollection<BookCollection>? Collections { get; set; }
}