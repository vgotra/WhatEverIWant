namespace WhatEverIWant.Services.Models.Books;

public class UpdateBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public DateTime? PublishedDate { get; set; }
}