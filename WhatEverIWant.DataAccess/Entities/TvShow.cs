namespace WhatEverIWant.DataAccess.Entities;

public class TvShow : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int? StartYear { get; set; }
    public int? EndYear { get; set; }

    public ICollection<TvShowCollection>? Collections { get; set; }
}