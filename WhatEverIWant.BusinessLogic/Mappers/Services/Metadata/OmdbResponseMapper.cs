using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.BusinessLogic.Mappers.Services.Metadata;

[Mapper]
public partial class OmdbResponseMapper : IOmdbResponseMapper 
{
    public partial MetadataMovieResponse ToMetadataMovie(OmdbResponse omdbResponse);
    
    //TODO Check this out later
    private MetadataItemType MapOmdbItemTypeToMetadataItemType(OmdbItemType omdbItemType)
    {
        return omdbItemType switch
        {
            OmdbItemType.Movie => MetadataItemType.Movie,
            OmdbItemType.Series => MetadataItemType.Series,
            OmdbItemType.Episode => MetadataItemType.Episode,
            _ => throw new ArgumentOutOfRangeException(nameof(omdbItemType), omdbItemType, null)
        };
    }
}