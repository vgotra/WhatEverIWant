namespace WhatEverIWant.DataAccess.Entities;

public class TvShow : EntityBase<long>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<TvShowCollection>? Collections { get; set; }
}