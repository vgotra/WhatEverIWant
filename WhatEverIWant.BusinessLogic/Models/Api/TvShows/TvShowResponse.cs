namespace WhatEverIWant.BusinessLogic.Models.Api.TvShows;

public class TvShowResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}