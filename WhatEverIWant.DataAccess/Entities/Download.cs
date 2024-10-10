namespace WhatEverIWant.DataAccess.Entities;

public class Download
{
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public required string Status { get; set; } //TODO Enum
    public DateTime CreatedAt { get; set; }

    public ICollection<MoviesDownload>? MoviesDownloads { get; set; }
    public ICollection<SeriesDownload>? SeriesDownloads { get; set; }
    public ICollection<MusicDownload>? MusicDownloads { get; set; }
    public ICollection<BookDownload>? BookDownloads { get; set; }
    public ICollection<AudioBookDownload>? AudioBookDownloads { get; set; }
}