using WhatEverIWant.Services;
using WhatEverIWant.Services.Models.Series;

namespace WhatEverIWant.Api.Api;

public static class SeriesApi
{
    public static void MapSeriesApi(this WebApplication app)
    {
        var group = app.MapGroup("/api/series")
            .WithTags("Series");

        group.MapGet("/", async (ISeriesService seriesService) =>
            {
                var seriesList = await seriesService.GetAllAsync();
                return Results.Ok(seriesList);
            })
            .WithName("GetAllSeries")
            .WithDescription("Retrieves all series.")
            .Produces<IEnumerable<SeriesResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Guid id, ISeriesService seriesService) =>
            {
                var series = await seriesService.GetByIdAsync(id);
                return series != null ? Results.Ok(series) : Results.NotFound();
            })
            .WithName("GetSeriesById")
            .WithDescription("Retrieves a specific series by unique id.")
            .Produces<SeriesResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateSeriesRequest request, ISeriesService seriesService) =>
            {
                var createdSeries = await seriesService.CreateAsync(request);
                return Results.Created($"/api/series/{createdSeries.Id}", createdSeries);
            })
            .WithName("CreateSeries")
            .WithDescription("Creates a new series.")
            .Accepts<CreateSeriesRequest>("application/json")
            .Produces<SeriesResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async (Guid id, UpdateSeriesRequest request, ISeriesService seriesService) =>
            {
                var updated = await seriesService.UpdateAsync(id, request);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateSeries")
            .WithDescription("Updates an existing series.")
            .Accepts<UpdateSeriesRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async (Guid id, ISeriesService seriesService) =>
            {
                var deleted = await seriesService.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteSeries")
            .WithDescription("Deletes a specific series by unique id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}