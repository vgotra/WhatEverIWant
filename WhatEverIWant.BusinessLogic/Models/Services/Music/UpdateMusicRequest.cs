namespace WhatEverIWant.BusinessLogic.Models.Services.Music;

public class UpdateMusicRequest
{
    public string Title { get; set; } = null!;
    public string Artist { get; set; } = null!;
    public string Album { get; set; } = null!;
    public int? Year { get; set; }
}