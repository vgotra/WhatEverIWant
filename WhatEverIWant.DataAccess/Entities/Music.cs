namespace WhatEverIWant.DataAccess.Entities;

public class Music : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Artist { get; set; } //TODO Maybe separate collection of artists
    public string? Album { get; set; } //TODO Think about albums
    public int? Year { get; set; }

    public ICollection<MusicCollection>? Collections { get; set; }
}