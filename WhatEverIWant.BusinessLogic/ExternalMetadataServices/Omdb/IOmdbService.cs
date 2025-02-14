using WhatEverIWant.BusinessLogic.Models.External.Omdb;
using WhatEverIWant.BusinessLogic.Models.Services.Metadata;

namespace WhatEverIWant.BusinessLogic.ExternalMetadataServices.Omdb;

public interface IOmdbService
{
    Task<MetadataItemResponse?> GetOmdbItemAsync(OmdbRequest request);
}