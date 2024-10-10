namespace WhatEverIWant.DataAccess.Entities;

public class MusicCollectionItem
{
    public Guid MusicCollectionId { get; set; }
    public MusicCollection MusicCollection { get; set; }

    public Guid MusicId { get; set; }
    public Music Music { get; set; }
}