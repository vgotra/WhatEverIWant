using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.Models.Services.Music;
using WhatEverIWant.BusinessLogic.Services;

namespace WhatEverIWant.Api.Api;

public static class MusicCrudApi
{
    const string BaseRoute = "/api/music";
    
    public static void MapMusicApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("Music");

        group.MapGet("/", async (IMusicService musicService) => await musicService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllMusic", "Retrieves all music records.")
            .Produces<IEnumerable<MusicResponse>>();

        group.MapGet("/{id:long}", async (long id, IMusicService musicService) => await musicService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetMusicById", "Retrieves a specific music record by unique id.")
            .Produces<MusicResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateMusicRequest request, IMusicService musicService) => await musicService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateMusic", "Creates a new music record.")
            .Accepts<CreateMusicRequest>("application/json")
            .Produces<MusicResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id:long}", async (long id, UpdateMusicRequest request, IMusicService musicService) => await musicService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateMusic", "Updates an existing music record.")
            .Accepts<UpdateMusicRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id:long}", async (long id, IMusicService musicService) => await musicService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteMusic", "Deletes a specific music record by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}