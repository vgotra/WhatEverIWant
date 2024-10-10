using Riok.Mapperly.Abstractions;
using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.Services.Models.Movies;

namespace WhatEverIWant.Services.Mappers;

[Mapper]
public partial class MovieMapper : IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>
{
    public partial Movie ToEntity(CreateMovieRequest createModel);

    public partial void UpdateEntity(UpdateMovieRequest updateModel, Movie entity);

    public partial MovieResponse ToResponse(Movie entity);
}