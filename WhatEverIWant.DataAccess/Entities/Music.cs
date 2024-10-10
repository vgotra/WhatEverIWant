namespace WhatEverIWant.DataAccess.Entities;

public class Music
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Artist { get; set; } //TODO Maybe separate collection of artists
    public string? Album { get; set; } //TODO Think about albums
    public DateTime? ReleaseDate { get; set; }

    public ICollection<MusicDownload>? MusicDownloads { get; set; }
    public ICollection<MusicCollectionItem>? MusicCollectionItems { get; set; }
}