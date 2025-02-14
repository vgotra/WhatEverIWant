using WhatEverIWant.BusinessLogic.Models.External.Omdb;
using WhatEverIWant.BusinessLogic.Models.Services.Metadata;

namespace WhatEverIWant.BusinessLogic.Mappers.Services.Metadata;

public interface IOmdbResponseMapper
{
    MetadataMovieResponse ToMetadataMovie(OmdbResponse omdbResponse);
}