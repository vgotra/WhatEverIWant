namespace WhatEverIWant.BusinessLogic.Models.Api.TvShows;

public class CreateTvShowRequest
{
    public string Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}