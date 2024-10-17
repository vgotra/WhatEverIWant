using WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

namespace WhatEverIWant.BusinessLogic.Models.External.Omdb;

public class OmdbResponse
{
    public required string Title { get; set; }

    public int? Year { get; set; }

    public string? Rated { get; set; }

    [JsonConverter(typeof(OmdbDateTimeConverter))]
    public DateTime Released { get; set; }

    [JsonConverter(typeof(OmdbRuntimeConverter))]
    public TimeSpan Runtime { get; set; }

    [JsonConverter(typeof(OmdbListStringConverter)), JsonPropertyName("genre")]
    public List<string>? Genres { get; set; }

    public string? Director { get; set; }

    public string? Writer { get; set; }

    [JsonConverter(typeof(OmdbListStringConverter))]
    public List<string>? Actors { get; set; }

    public string? Plot { get; set; }

    [JsonConverter(typeof(OmdbListStringConverter)), JsonPropertyName("language")]
    public List<string>? Languages { get; set; }

    [JsonConverter(typeof(OmdbListStringConverter))]
    public List<string>? Country { get; set; }

    public string? Poster { get; set; }

    public List<OmdbRating>? Ratings { get; set; }

    public int? Metascore { get; set; }

    public string? ImdbRating { get; set; }

    public string? ImdbId { get; set; }

    [JsonConverter(typeof(OmdbItemTypeConverter))]
    public OmdbItemType Type { get; set; }
}