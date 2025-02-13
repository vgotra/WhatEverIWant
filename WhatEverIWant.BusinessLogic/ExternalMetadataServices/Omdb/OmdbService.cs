using Microsoft.Extensions.Options;
using WhatEverIWant.BusinessLogic.JsonCustomSerializers.Omdb;
using WhatEverIWant.BusinessLogic.Mappers.Services.Metadata;
using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.ExternalMetadataServices.Omdb;

public class OmdbService(IOmdbResponseMapper responseMapper, IHttpClientFactory httpClientFactory, IOptions<OmdbServiceSettings> settings) : MetadataServiceBase(responseMapper), IOmdbService
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { new OmdbDateTimeConverter(), new OmdbListStringConverter(), new OmdbRuntimeConverter(), new OmdbItemTypeConverter() },
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public async Task<MetadataItemResponse?> GetOmdbItemAsync(OmdbRequest request)
    {
        var client = httpClientFactory.CreateClient("OMDB");
        var url = BuildQuery(request, settings.Value);
        var response = await client.GetStringAsync(url);
        var omdbItem = JsonSerializer.Deserialize<OmdbResponse>(response, Options);
        var metadataItem = ConvertToMetadataItem(omdbItem);
        return metadataItem;
    }

    private string BuildQuery(OmdbRequest request, OmdbServiceSettings omdbSettings)
    {
        var query = $"?apikey={omdbSettings.ApiKey}&r=json&plot=full";

        if (!string.IsNullOrWhiteSpace(request.ImdbId))
            query += $"&i={request.ImdbId}";

        if (!string.IsNullOrWhiteSpace(request.Title))
            query += $"&t={request.Title}";

        if (!string.IsNullOrWhiteSpace(request.Year))
            query += $"&y={request.Year}";

        if (request.Type != OmdbItemType.Unknown)
            query += $"&type={request.Type.ToString().ToLowerInvariant()}";

        return query;
    }
}