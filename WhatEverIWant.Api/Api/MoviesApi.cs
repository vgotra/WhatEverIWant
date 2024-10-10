using WhatEverIWant.Services;
using WhatEverIWant.Services.Models.Movies;

namespace WhatEverIWant.Api.Api;

public static class MoviesApi
{
    public static void MapMoviesApi(this WebApplication app)
    {
        var group = app.MapGroup("/api/movies")
            .WithTags("Movies");

        group.MapGet("/", async (IMovieService movieService) =>
            {
                var movies = await movieService.GetAllAsync();
                return Results.Ok(movies);
            })
            .WithName("GetAllMovies")
            .WithDescription("Retrieves all movies.")
            .Produces<IEnumerable<MovieResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Guid id, IMovieService movieService) =>
            {
                var movie = await movieService.GetByIdAsync(id);
                return movie != null ? Results.Ok(movie) : Results.NotFound();
            })
            .WithName("GetMovieById")
            .WithDescription("Retrieves a specific movie by unique id.")
            .Produces<MovieResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateMovieRequest request, IMovieService movieService) =>
            {
                var createdMovie = await movieService.CreateAsync(request);
                return Results.Created($"/api/movies/{createdMovie.Id}", createdMovie);
            })
            .WithName("CreateMovie")
            .WithDescription("Creates a new movie.")
            .Accepts<CreateMovieRequest>("application/json")
            .Produces<MovieResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async (Guid id, UpdateMovieRequest request, IMovieService movieService) =>
            {
                var updated = await movieService.UpdateAsync(id, request);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateMovie")
            .WithDescription("Updates an existing movie.")
            .Accepts<UpdateMovieRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async (Guid id, IMovieService movieService) =>
            {
                var deleted = await movieService.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteMovie")
            .WithDescription("Deletes a specific movie by unique id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}