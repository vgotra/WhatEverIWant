using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.Models.Services.Movies;
using WhatEverIWant.BusinessLogic.Services;

namespace WhatEverIWant.Api.Api;

public static class MoviesCrudApi
{
    const string BaseRoute = "/api/movies";
    
    public static void MapMoviesApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("Movies");

        group.MapGet("/", async (IMovieService movieService) => await movieService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllMovies", "Retrieves all movies.")
            .Produces<IEnumerable<MovieResponse>>();

        group.MapGet("/{id:long}", async (long id, IMovieService movieService) => await movieService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetMovieById", "Retrieves a specific movie by unique id.")
            .Produces<MovieResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateMovieRequest request, IMovieService movieService) => await movieService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateMovie", "Creates a new movie.")
            .Accepts<CreateMovieRequest>("application/json")
            .Produces<MovieResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id:long}", async (long id, UpdateMovieRequest request, IMovieService movieService) => await movieService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateMovie", "Updates an existing movie.")
            .Accepts<UpdateMovieRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id:long}", async (long id, IMovieService movieService) => await movieService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteMovie", "Deletes a specific movie by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}