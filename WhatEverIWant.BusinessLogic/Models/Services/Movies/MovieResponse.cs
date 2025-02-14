namespace WhatEverIWant.BusinessLogic.Models.Services.Movies;

public class MovieResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? Year { get; set; }
}