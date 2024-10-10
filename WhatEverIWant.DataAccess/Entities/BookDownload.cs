namespace WhatEverIWant.DataAccess.Entities;

public class BookDownload
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public Guid DownloadId { get; set; }
    public Download Download { get; set; }
}