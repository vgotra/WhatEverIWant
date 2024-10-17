using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.ExternalMetadataServices.Omdb;
using WhatEverIWant.BusinessLogic.Models.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.External.Omdb;

namespace WhatEverIWant.Api.Api.Metadata;

public static class ExternalMetadataMoviesApi
{
    const string BaseRoute = "/api/external/metadata/movies";
    
    public static void MapExternalMetadataApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("Metadata", "Movies");

        //TODO Generic for few services
        group.MapPost("/search", async (OmdbRequest request, IOmdbService omdbService) => await omdbService.GetOmdbItemAsync(request).OkOrNotFoundAsync())
            .WithEndpointMetadata("SearchOmdb", "Search OMDB.")
            .Accepts<OmdbRequest>("application/json")
            .Produces<MetadataMovieResponse>(); //TODO Add support for different types later
    }
}