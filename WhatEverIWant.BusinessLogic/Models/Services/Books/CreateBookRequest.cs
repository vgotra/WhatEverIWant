namespace WhatEverIWant.BusinessLogic.Models.Services.Books;

public class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string? Isbn { get; set; }
    public int? Year { get; set; }
}