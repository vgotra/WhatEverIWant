using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.ExternalMetadataServices.Omdb;

public interface IOmdbService
{
    Task<MetadataItemResponse?> GetOmdbItemAsync(OmdbRequest request);
}