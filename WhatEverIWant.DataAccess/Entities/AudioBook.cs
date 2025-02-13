namespace WhatEverIWant.DataAccess.Entities;

public class AudioBook : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Isbn { get; set; }
    public required string Narrator { get; set; }
    public DateTime? PublishedDate { get; set; }

    public ICollection<AudioBookCollection>? Collections { get; set; }
}