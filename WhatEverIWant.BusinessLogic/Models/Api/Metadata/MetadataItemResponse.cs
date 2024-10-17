using WhatEverIWant.BusinessLogic.JsonCustomSerializers;

namespace WhatEverIWant.BusinessLogic.Models.Api.Metadata;

public class MetadataItemResponse
{
    [JsonConverter(typeof(MetadataItemTypeJsonConverter))]
    public required MetadataItemType Type { get; set; }
}