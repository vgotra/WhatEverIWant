using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Books;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers;

[Mapper]
public partial class BookMapper : IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book>
{
    public partial Book ToEntity(CreateBookRequest createModel);

    public partial void UpdateEntity(UpdateBookRequest updateModel, Book entity);

    public partial BookResponse ToResponse(Book entity);
}