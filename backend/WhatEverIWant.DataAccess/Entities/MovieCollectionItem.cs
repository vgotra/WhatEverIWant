namespace WhatEverIWant.DataAccess.Entities;

public class MovieCollectionItem
{
    public Guid MovieCollectionId { get; set; }
    public MovieCollection MovieCollection { get; set; }

    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
}