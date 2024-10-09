namespace WhatEverIWant.Services.Models.Music;

public class MusicResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public DateTime? ReleaseDate { get; set; }
}