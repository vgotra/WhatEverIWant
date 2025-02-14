namespace WhatEverIWant.BusinessLogic.Models.Services.Movies;

public class UpdateMovieRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? Year { get; set; }
}