using WhatEverIWant.BusinessLogic.Models.Api.Metadata;

namespace WhatEverIWant.BusinessLogic.JsonCustomSerializers;

public class MetadataItemTypeJsonConverter : JsonConverter<MetadataItemType>
{
    public override MetadataItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var typeString = reader.GetString();
        if (Enum.TryParse<MetadataItemType>(typeString, out var type))
            return type;
        
        throw new JsonException($"Unable to convert \"{typeString}\" to {nameof(MetadataItemType)}");
    }

    public override void Write(Utf8JsonWriter writer, MetadataItemType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}