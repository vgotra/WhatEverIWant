namespace WhatEverIWant.DataAccess.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public ICollection<MoviesDownload>? MoviesDownloads { get; set; }
    public ICollection<MovieCollectionItem>? MovieCollectionItems { get; set; }
}