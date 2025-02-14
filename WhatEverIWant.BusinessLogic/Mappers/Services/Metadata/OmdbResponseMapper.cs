using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;
using WhatEverIWant.BusinessLogic.Models.Services.Metadata;

namespace WhatEverIWant.BusinessLogic.Mappers.Services.Metadata;

[Mapper]
public partial class OmdbResponseMapper : IOmdbResponseMapper 
{
    [MapperIgnoreSource(nameof(OmdbResponse.Released))]
    [MapperIgnoreSource(nameof(OmdbResponse.Writer))]
    [MapperIgnoreSource(nameof(OmdbResponse.ImdbRating))]
    [MapperIgnoreSource(nameof(OmdbResponse.Ratings))]
    [MapperIgnoreSource(nameof(OmdbResponse.ImdbId))]
    [MapperIgnoreSource(nameof(OmdbResponse.Metascore))]
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