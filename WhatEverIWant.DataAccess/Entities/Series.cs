namespace WhatEverIWant.DataAccess.Entities;

public class Series
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<SeriesDownload>? SeriesDownloads { get; set; }
    public ICollection<SeriesCollectionItem>? SeriesCollectionItems { get; set; }
}