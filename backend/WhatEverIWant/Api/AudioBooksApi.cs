using WhatEverIWant.Services;
using WhatEverIWant.Services.Models.AudioBooks;

namespace WhatEverIWant.Api;

public static class AudioBooksApi
{
    public static void MapAudioBooksApi(this WebApplication app)
    {
        var group = app.MapGroup("/api/audiobooks")
            .WithTags("AudioBooks");

        group.MapGet("/", async (IAudioBookService audioBookService) =>
            {
                var audioBooks = await audioBookService.GetAllAsync();
                return Results.Ok(audioBooks);
            })
            .WithName("GetAllAudioBooks")
            .WithDescription("Retrieves all audiobooks.")
            .Produces<IEnumerable<AudioBookResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Guid id, IAudioBookService audioBookService) =>
            {
                var audioBook = await audioBookService.GetByIdAsync(id);
                return audioBook != null ? Results.Ok(audioBook) : Results.NotFound();
            })
            .WithName("GetAudioBookById")
            .WithDescription("Retrieves a specific audiobook by unique id.")
            .Produces<AudioBookResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateAudioBookRequest request, IAudioBookService audioBookService) =>
            {
                var createdAudioBook = await audioBookService.CreateAsync(request);
                return Results.Created($"/api/audiobooks/{createdAudioBook.Id}", createdAudioBook);
            })
            .WithName("CreateAudioBook")
            .WithDescription("Creates a new audiobook.")
            .Accepts<CreateAudioBookRequest>("application/json")
            .Produces<AudioBookResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async (Guid id, UpdateAudioBookRequest request, IAudioBookService audioBookService) =>
            {
                var updated = await audioBookService.UpdateAsync(id, request);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateAudioBook")
            .WithDescription("Updates an existing audiobook.")
            .Accepts<UpdateAudioBookRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async (Guid id, IAudioBookService audioBookService) =>
            {
                var deleted = await audioBookService.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteAudioBook")
            .WithDescription("Deletes a specific audiobook by unique id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}