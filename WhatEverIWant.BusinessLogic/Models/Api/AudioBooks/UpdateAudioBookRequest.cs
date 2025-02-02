namespace WhatEverIWant.BusinessLogic.Models.Api.AudioBooks;

public class UpdateAudioBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public string Narrator { get; set; }
    public DateTime? PublishedDate { get; set; }
}