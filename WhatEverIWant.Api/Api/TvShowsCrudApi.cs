using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.Models.Services.TvShows;
using WhatEverIWant.BusinessLogic.Services;

namespace WhatEverIWant.Api.Api;

public static class TvShowsCrudApi
{
    const string BaseRoute = "/api/tvshows";
    
    public static void MapSeriesApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("TvShows");

        group.MapGet("/", async Task (ITvShowsService seriesService) => await seriesService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllTvShows", "Retrieves all tv shows.")
            .Produces<IEnumerable<TvShowResponse>>();

        group.MapGet("/{id:long}", async Task (long id, ITvShowsService seriesService) => await seriesService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetTvShowById", "Retrieves a specific tv show by unique id.")
            .Produces<TvShowResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async Task (CreateTvShowRequest request, ITvShowsService seriesService) => await seriesService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateTvShow", "Creates a new tv show.")
            .Accepts<CreateTvShowRequest>("application/json")
            .Produces<TvShowResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id:long}", async Task (long id, UpdateTvShowRequest request, ITvShowsService seriesService) => await seriesService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateTvShow", "Updates an existing tv show.")
            .Accepts<UpdateTvShowRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id:long}", async Task (long id, ITvShowsService seriesService) => await seriesService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteTvShow", "Deletes a specific tv show by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}