namespace WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

public class OmdbRuntimeConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var runtime = reader.GetString();
        if (string.IsNullOrWhiteSpace(runtime))
            throw new JsonException("Runtime cannot be null or empty");

        var parts = runtime.Split(' ');
        if (parts is not [_, "min"])
            throw new JsonException("Runtime format is invalid");

        if (!int.TryParse(parts[0], out var minutes))
            throw new JsonException("Runtime format is invalid");

        return TimeSpan.FromMinutes(minutes);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("c"));
    }
}