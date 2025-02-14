using WhatEverIWant.BusinessLogic.JsonCustomSerializers;

namespace WhatEverIWant.BusinessLogic.Models.Services.Metadata;

public class MetadataItemResponse
{
    [JsonConverter(typeof(MetadataItemTypeJsonConverter))]
    public required MetadataItemType Type { get; set; }
}