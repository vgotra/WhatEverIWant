namespace WhatEverIWant.DataAccess.Entities;

public class MusicDownload
{
    public Guid MusicId { get; set; }
    public Music Music { get; set; }

    public Guid DownloadId { get; set; }
    public Download Download { get; set; }
}