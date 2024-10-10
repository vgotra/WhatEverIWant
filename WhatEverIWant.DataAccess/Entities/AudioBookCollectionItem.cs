namespace WhatEverIWant.DataAccess.Entities;

public class AudioBookCollectionItem
{
    public Guid AudioBookCollectionId { get; set; }
    public AudioBookCollection AudioBookCollection { get; set; }

    public Guid AudioBookId { get; set; }
    public AudioBook AudioBook { get; set; }
}