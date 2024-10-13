namespace WhatEverIWant.BusinessLogic.Models.Music;

public class CreateMusicRequest
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public DateTime? ReleaseDate { get; set; }
}