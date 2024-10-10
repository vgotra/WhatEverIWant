namespace WhatEverIWant.DataAccess.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public DateTime? PublishedDate { get; set; }

    public ICollection<BookDownload>? BookDownloads { get; set; }
    public ICollection<BookCollectionItem>? BookCollectionItems { get; set; }
}