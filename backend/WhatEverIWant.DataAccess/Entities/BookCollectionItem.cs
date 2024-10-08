namespace WhatEverIWant.DataAccess.Entities;

public class BookCollectionItem
{
    public Guid BookCollectionId { get; set; }
    public BookCollection BookCollection { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }
}