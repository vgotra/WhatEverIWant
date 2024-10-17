namespace WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;

public class OmdbDateTimeConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "dd MMM yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (string.IsNullOrWhiteSpace(dateString))
            throw new JsonException("Date string cannot be null or empty");

        if (!DateTime.TryParseExact(dateString, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            throw new JsonException($"Date string '{dateString}' is not in the correct format");

        return date;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}