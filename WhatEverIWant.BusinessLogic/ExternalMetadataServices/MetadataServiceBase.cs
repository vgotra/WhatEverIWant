using WhatEverIWant.BusinessLogic.Mappers.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.ExternalMetadataServices;

public abstract class MetadataServiceBase(IOmdbResponseMapper responseMapper)
{
    protected MetadataItemResponse? ConvertToMetadataItem<T>(T itemResponse)
    {
        if (itemResponse is null)
            return null;

        if (itemResponse is OmdbResponse omdbMovieResponse)
        {
            var response = responseMapper.ToMetadataMovie(omdbMovieResponse);
            return response;
        }

        return null;
    }
}