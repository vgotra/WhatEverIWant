using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

public class OmdbItemTypeConverter : JsonConverter<OmdbItemType>
{
    public override OmdbItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value?.ToLower() switch
        {
            "movie" => OmdbItemType.Movie,
            "series" => OmdbItemType.Series,
            "episode" => OmdbItemType.Episode,
            _ => throw new JsonException($"Unknown OmdbItemType value: {value}")
        };
    }

    public override void Write(Utf8JsonWriter writer, OmdbItemType value, JsonSerializerOptions options)
    {
        var stringValue = value switch
        {
            OmdbItemType.Movie => "movie",
            OmdbItemType.Series => "series",
            OmdbItemType.Episode => "episode",
            _ => throw new JsonException($"Unknown OmdbItemType value: {value}")
        };
        writer.WriteStringValue(stringValue);
    }
}