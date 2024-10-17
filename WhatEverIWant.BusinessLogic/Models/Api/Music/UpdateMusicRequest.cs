namespace WhatEverIWant.BusinessLogic.Models.Api.Music;

public class UpdateMusicRequest
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public DateTime? ReleaseDate { get; set; }
}