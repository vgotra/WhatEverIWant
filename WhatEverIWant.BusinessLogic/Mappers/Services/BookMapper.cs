using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Services.Books;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class BookMapper : IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book>
{
    [MapperIgnoreTarget(nameof(Book.Id))]
    [MapperIgnoreTarget(nameof(Book.Collections))]
    public partial Book ToEntity(CreateBookRequest createModel);

    [MapperIgnoreTarget(nameof(Book.Id))]
    [MapperIgnoreTarget(nameof(Book.Collections))]
    public partial void UpdateEntity(UpdateBookRequest updateModel, Book entity);

    [MapperIgnoreSource(nameof(Book.Collections))]
    public partial BookResponse ToResponse(Book entity);
}