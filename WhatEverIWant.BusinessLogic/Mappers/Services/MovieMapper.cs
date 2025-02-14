using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Services.Movies;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Services;

[Mapper]
public partial class MovieMapper : IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>
{
    [MapperIgnoreTarget(nameof(Movie.Id))]
    [MapperIgnoreTarget(nameof(Movie.Collections))]
    public partial Movie ToEntity(CreateMovieRequest createModel);

    [MapperIgnoreTarget(nameof(Movie.Id))]
    [MapperIgnoreTarget(nameof(Movie.Collections))]
    public partial void UpdateEntity(UpdateMovieRequest updateModel, Movie entity);

    [MapperIgnoreSource(nameof(Movie.Collections))]
    public partial MovieResponse ToResponse(Movie entity);
}