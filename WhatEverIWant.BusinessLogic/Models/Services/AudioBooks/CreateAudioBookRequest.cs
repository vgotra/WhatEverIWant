namespace WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;

public class CreateAudioBookRequest
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string? Isbn { get; set; }
    public string? Narrator { get; set; }
    public int? Year { get; set; }
}