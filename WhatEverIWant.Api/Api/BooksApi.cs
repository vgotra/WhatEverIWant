using WhatEverIWant.Services;
using WhatEverIWant.Services.Models.Books;

namespace WhatEverIWant.Api.Api;

public static class BooksApi
{
    public static void MapBooksApi(this WebApplication app)
    {
        var group = app.MapGroup("/api/books")
            .WithTags("Books");

        group.MapGet("/", async (IBookService bookService) =>
            {
                var books = await bookService.GetAllAsync();
                return Results.Ok(books);
            })
            .WithName("GetAllBooks")
            .WithDescription("Retrieves all books.")
            .Produces<IEnumerable<BookResponse>>(StatusCodes.Status200OK);

        group.MapGet("/{id}", async (Guid id, IBookService bookService) =>
            {
                var book = await bookService.GetByIdAsync(id);
                return book != null ? Results.Ok(book) : Results.NotFound();
            })
            .WithName("GetBookById")
            .WithDescription("Retrieves a specific book by unique id.")
            .Produces<BookResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async (CreateBookRequest request, IBookService bookService) =>
            {
                var createdBook = await bookService.CreateAsync(request);
                return Results.Created($"/api/books/{createdBook.Id}", createdBook);
            })
            .WithName("CreateBook")
            .WithDescription("Creates a new book.")
            .Accepts<CreateBookRequest>("application/json")
            .Produces<BookResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id}", async (Guid id, UpdateBookRequest request, IBookService bookService) =>
            {
                var updated = await bookService.UpdateAsync(id, request);
                return updated ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateBook")
            .WithDescription("Updates an existing book.")
            .Accepts<UpdateBookRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id}", async (Guid id, IBookService bookService) =>
            {
                var deleted = await bookService.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteBook")
            .WithDescription("Deletes a specific book by unique id.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
    }
}