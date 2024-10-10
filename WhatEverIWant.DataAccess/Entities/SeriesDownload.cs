namespace WhatEverIWant.DataAccess.Entities;

public class SeriesDownload
{
    public Guid SeriesId { get; set; }
    public Series Series { get; set; }

    public Guid DownloadId { get; set; }
    public Download Download { get; set; }
}