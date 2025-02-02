namespace WhatEverIWant.BusinessLogic.Models.Api.Books;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public DateTime? PublishedDate { get; set; }
}