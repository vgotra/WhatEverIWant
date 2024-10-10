using WhatEverIWant.Services;
using WhatEverIWant.Services.Models.Music;

namespace WhatEverIWant.Api;

public static class MusicApi
{
    public static void MapMusicApi(this WebApplication app)
    {
        var group = app.MapGroup("/api/music")
            .WithTags("Music");

        group.MapGet("/", async (IMusicService musicService) =>
            {
                var musicList = await musicService.GetAllAsync();
                return Results.Ok(musicList);
            })
            .WithName("GetAllMusic")
            .WithDescription("Retrieves all music records.")
            .Produces<IEnumerable<MusicResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Guid id, IMusicService musicService) =>
            {
                var music = await musicService.GetByIdAsync(id);
                return music != null ? Results.Ok(music) : Results.NotFound();
            })
            .WithName("GetMusicById")
            .WithDescription("Retrieves a specific music record by unique id.")
            .Produces<MusicResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateMusicRequest request, IMusicService musicService) =>
            {
                var createdMusic = await musicService.CreateAsync(request);
                return Results.Created($"/api/music/{createdMusic.Id}", createdMusic);
            })
            .WithName("CreateMusic")
            .WithDescription("Creates a new music record.")
            .Accepts<CreateMusicRequest>("application/json")
            .Produces<MusicResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async (Guid id, UpdateMusicRequest request, IMusicService musicService) =>
            {
                var updated = await musicService.UpdateAsync(id, request);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateMusic")
            .WithDescription("Updates an existing music record.")
            .Accepts<UpdateMusicRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async (Guid id, IMusicService musicService) =>
            {
                var deleted = await musicService.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteMusic")
            .WithDescription("Deletes a specific music record by unique id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}