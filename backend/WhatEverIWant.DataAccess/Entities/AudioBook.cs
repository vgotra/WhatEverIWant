namespace WhatEverIWant.DataAccess.Entities;

public class AudioBook
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public required string Narrator { get; set; }
    public DateTime? PublishedDate { get; set; }

    public ICollection<AudioBookDownload>? AudioBookDownloads { get; set; }
    public ICollection<AudioBookCollectionItem>? AudioBookCollectionItems { get; set; }
}