namespace WhatEverIWant.BusinessLogic.Models.Series;

public class CreateSeriesRequest
{
    public string Title { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
}