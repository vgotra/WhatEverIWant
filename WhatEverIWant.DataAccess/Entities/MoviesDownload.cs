namespace WhatEverIWant.DataAccess.Entities;

public class MoviesDownload
{
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }

    public Guid DownloadId { get; set; }
    public Download Download { get; set; }
}