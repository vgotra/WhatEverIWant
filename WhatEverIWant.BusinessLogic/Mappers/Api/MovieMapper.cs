using Riok.Mapperly.Abstractions;
using WhatEverIWant.BusinessLogic.Models.Api.Movies;
using WhatEverIWant.DataAccess.Entities;

namespace WhatEverIWant.BusinessLogic.Mappers.Api;

[Mapper]
public partial class MovieMapper : IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>
{
    public partial Movie ToEntity(CreateMovieRequest createModel);

    public partial void UpdateEntity(UpdateMovieRequest updateModel, Movie entity);

    public partial MovieResponse ToResponse(Movie entity);
}