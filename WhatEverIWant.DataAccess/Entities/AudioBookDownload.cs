namespace WhatEverIWant.DataAccess.Entities;

public class AudioBookDownload
{
    public Guid AudioBookId { get; set; }
    public AudioBook AudioBook { get; set; }

    public Guid DownloadId { get; set; }
    public Download Download { get; set; }
}