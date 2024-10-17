using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.ApiServices;
using WhatEverIWant.BusinessLogic.Models.Api.Series;

namespace WhatEverIWant.Api.Api;

public static class SeriesCrudApi
{
    const string BaseRoute = "/api/series";
    
    public static void MapSeriesApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("Series");

        group.MapGet("/", async Task (ISeriesService seriesService) => await seriesService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllSeries", "Retrieves all series.")
            .Produces<IEnumerable<SeriesResponse>>();

        group.MapGet("/{id}", async Task (Guid id, ISeriesService seriesService) => await seriesService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetSeriesById", "Retrieves a specific series by unique id.")
            .Produces<SeriesResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async Task (CreateSeriesRequest request, ISeriesService seriesService) => await seriesService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateSeries", "Creates a new series.")
            .Accepts<CreateSeriesRequest>("application/json")
            .Produces<SeriesResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async Task (Guid id, UpdateSeriesRequest request, ISeriesService seriesService) => await seriesService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateSeries", "Updates an existing series.")
            .Accepts<UpdateSeriesRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async Task (Guid id, ISeriesService seriesService) => await seriesService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteSeries", "Deletes a specific series by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}