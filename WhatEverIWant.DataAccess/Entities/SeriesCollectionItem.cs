namespace WhatEverIWant.DataAccess.Entities;

public class SeriesCollectionItem
{
    public Guid SeriesCollectionId { get; set; }
    public SeriesCollection SeriesCollection { get; set; }

    public Guid SeriesId { get; set; }
    public Series Series { get; set; }
}