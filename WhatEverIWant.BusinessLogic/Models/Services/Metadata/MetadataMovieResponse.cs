using WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

namespace WhatEverIWant.BusinessLogic.Models.Services.Metadata;

public class MetadataMovieResponse : MetadataItemResponse
{
    public required string Title { get; set; }

    public int? Year { get; set; }

    public string? Rated { get; set; }

    [JsonConverter(typeof(OmdbRuntimeConverter))]
    public TimeSpan Runtime { get; set; }

    public List<string>? Genres { get; set; }

    public string? Director { get; set; }

    public List<string>? Actors { get; set; }

    public string? Plot { get; set; }

    public List<string>? Languages { get; set; }

    public List<string>? Country { get; set; }

    public string? Poster { get; set; }
}