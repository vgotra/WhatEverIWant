namespace WhatEverIWant.DataAccess.Entities;

public class AudioBookCollectionItem
{
    public Guid AudioCollectionId { get; set; }
    public AudioBookCollection AudioCollection { get; set; }

    public Guid AudioBookId { get; set; }
    public AudioBook AudioBook { get; set; }
}