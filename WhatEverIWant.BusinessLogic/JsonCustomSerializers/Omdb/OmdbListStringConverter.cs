namespace WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

public class OmdbListStringConverter : JsonConverter<List<string>>
{
    public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var genreString = reader.GetString();
        if (string.IsNullOrWhiteSpace(genreString))
            throw new JsonException("String list cannot be null or empty");

        return genreString.Split(',').Select(g => g.Trim()).ToList();
    }

    public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(string.Join(", ", value));
    }
}