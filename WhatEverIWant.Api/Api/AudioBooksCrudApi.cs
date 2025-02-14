using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.Models.Services.AudioBooks;
using WhatEverIWant.BusinessLogic.Services;

namespace WhatEverIWant.Api.Api;

public static class AudioBooksCrudApi
{
    const string BaseRoute = "/api/audiobooks"; //TODO Can be good to move this to Default constants
    
    public static void MapAudioBooksApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("AudioBooks");

        group.MapGet("/", async Task (IAudioBookService audioBookService) => await audioBookService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllAudioBooks", "Retrieves all audiobooks.")
            .Produces<IEnumerable<AudioBookResponse>>();

        group.MapGet("/{id:long}", async Task (long id, IAudioBookService audioBookService) => await audioBookService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetAudioBookById", "Retrieves a specific audiobook by unique id.")
            .Produces<AudioBookResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async Task (CreateAudioBookRequest request, IAudioBookService audioBookService) => await audioBookService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateAudioBook" , "Creates a new audiobook.")
            .Accepts<CreateAudioBookRequest>("application/json")
            .Produces<AudioBookResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id:long}", async Task (long id, UpdateAudioBookRequest request, IAudioBookService audioBookService) => await audioBookService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateAudioBook", "Updates an existing audiobook.")
            .Accepts<UpdateAudioBookRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id:long}", async Task (long id, IAudioBookService audioBookService) => await audioBookService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteAudioBook", "Deletes a specific audiobook by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}