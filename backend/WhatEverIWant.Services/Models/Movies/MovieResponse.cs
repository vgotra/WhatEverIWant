namespace WhatEverIWant.Services.Models.Movies;

public class MovieResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string Description { get; set; }
}