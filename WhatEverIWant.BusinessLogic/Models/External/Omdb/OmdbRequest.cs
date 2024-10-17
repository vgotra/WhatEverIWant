namespace WhatEverIWant.BusinessLogic.Models.External.Omdb;

public class OmdbRequest
{
    public string? ImdbId { get; set; }

    public string? Title { get; set; }

    public OmdbItemType Type { get; set; }

    public string? Year { get; set; }
}