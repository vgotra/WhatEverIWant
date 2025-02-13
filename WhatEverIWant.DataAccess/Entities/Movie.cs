namespace WhatEverIWant.DataAccess.Entities;

public class Movie : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public ICollection<MovieCollection>? Collections { get; set; }
}