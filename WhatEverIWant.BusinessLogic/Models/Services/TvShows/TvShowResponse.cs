namespace WhatEverIWant.BusinessLogic.Models.Services.TvShows;

public class TvShowResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? StartYear { get; set; }
    public int? EndYear { get; set; }
}