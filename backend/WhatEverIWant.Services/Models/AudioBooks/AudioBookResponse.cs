namespace WhatEverIWant.Services.Models.AudioBooks;

public class AudioBookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Narrator { get; set; }
    public DateTime? PublishedDate { get; set; }
}