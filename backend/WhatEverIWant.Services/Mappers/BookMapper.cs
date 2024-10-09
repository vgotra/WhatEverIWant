using Riok.Mapperly.Abstractions;
using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.Books;

namespace WhatEverIWant.Services.Mappers;

[Mapper]
public partial class BookMapper : IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book>
{
    public partial Book ToEntity(CreateBookRequest createModel);

    public partial void UpdateEntity(UpdateBookRequest updateModel, Book entity);

    public partial BookResponse ToResponse(Book entity);
}