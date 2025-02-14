namespace WhatEverIWant.DataAccess.Entities;

public class AudioBook : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? Isbn { get; set; }
    public string? Narrator { get; set; }
    public int? Year { get; set; }

    public ICollection<AudioBookCollection>? Collections { get; set; }
}