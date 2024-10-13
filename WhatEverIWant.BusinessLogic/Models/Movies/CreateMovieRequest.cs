namespace WhatEverIWant.BusinessLogic.Models.Movies;

public class CreateMovieRequest
{
    public string Title { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string Description { get; set; }
}