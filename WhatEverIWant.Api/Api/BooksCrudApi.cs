using WhatEverIWant.Api.Extensions;
using WhatEverIWant.BusinessLogic.Models.Services.Books;
using WhatEverIWant.BusinessLogic.Services;

namespace WhatEverIWant.Api.Api;

public static class BooksCrudApi
{
    const string BaseRoute = "/api/books";
    
    public static void MapBooksApi(this WebApplication app)
    {
        var group = app.MapGroup(BaseRoute).WithTags("Books");

        group.MapGet("/", async Task (IBookService bookService) => await bookService.GetAllAsync().OkAsync())
            .WithEndpointMetadata("GetAllBooks", "Retrieves all books.")
            .Produces<IEnumerable<BookResponse>>();

        group.MapGet("/{id:long}", async Task (long id, IBookService bookService) => await bookService.GetByIdAsync(id).OkOrNotFoundAsync())
            .WithEndpointMetadata("GetBookById", "Retrieves a specific book by unique id.")
            .Produces<BookResponse>()
            .Produces(StatusCodes.Status404NotFound);

        group.MapPost("/", async Task (CreateBookRequest request, IBookService bookService) => await bookService.CreateAsync(request).CreatedAsync(x => $"{BaseRoute}/{x.Id}"))
            .WithEndpointMetadata("CreateBook", "Creates a new book.")
            .Accepts<CreateBookRequest>("application/json")
            .Produces<BookResponse>(StatusCodes.Status201Created);

        group.MapPut("/{id:long}", async Task (long id, UpdateBookRequest request, IBookService bookService) => await bookService.UpdateAsync(id, request).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("UpdateBook", "Updates an existing book.")
            .Accepts<UpdateBookRequest>("application/json")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);

        group.MapDelete("/{id:long}", async Task (long id, IBookService bookService) => await bookService.DeleteAsync(id).NoContentOrNoFoundAsync())
            .WithEndpointMetadata("DeleteBook", "Deletes a specific book by unique id.")
            .Produces(StatusCodes.Status204NoContent, StatusCodes.Status404NotFound);
    }
}