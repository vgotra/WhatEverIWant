using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.Mappers.Api.Metadata;

public interface IOmdbResponseMapper
{
    MetadataMovieResponse ToMetadataMovie(OmdbResponse omdbResponse);
}