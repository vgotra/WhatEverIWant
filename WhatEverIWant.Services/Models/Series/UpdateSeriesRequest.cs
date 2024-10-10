namespace WhatEverIWant.Services.Models.Series;

public class UpdateSeriesRequest
{
    public string Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}