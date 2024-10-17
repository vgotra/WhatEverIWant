using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.BusinessLogic.Mappers.Api;
using WhatEverIWant.BusinessLogic.Mappers.Api.Metadata;
using WhatEverIWant.BusinessLogic.Models.Api.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Api.Books;
using WhatEverIWant.BusinessLogic.Models.Api.Movies;
using WhatEverIWant.BusinessLogic.Models.Api.Music;
using WhatEverIWant.BusinessLogic.Models.Api.Series;
using AudioBookMapper = WhatEverIWant.BusinessLogic.Mappers.Api.AudioBookMapper;
using BookMapper = WhatEverIWant.BusinessLogic.Mappers.Api.BookMapper;
using MovieMapper = WhatEverIWant.BusinessLogic.Mappers.Api.MovieMapper;
using MusicMapper = WhatEverIWant.BusinessLogic.Mappers.Api.MusicMapper;
using SeriesMapper = WhatEverIWant.BusinessLogic.Mappers.Api.SeriesMapper;

namespace WhatEverIWant.Api.Configuration;

public static class MapperConfiguration
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        // Mapperly generates and registers mapper implementations automatically
        // No explicit registration needed unless custom behavior is required

        services.AddScoped<IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>, MovieMapper>();
        services.AddScoped<IGenericMapper<CreateSeriesRequest, UpdateSeriesRequest, SeriesResponse, Series>, SeriesMapper>();
        services.AddScoped<IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>, MusicMapper>();
        services.AddScoped<IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book>, BookMapper>();
        services.AddScoped<IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>, AudioBookMapper>();
        
        services.AddScoped<IOmdbResponseMapper, OmdbResponseMapper>(); //TODO Move to metadata mapper or make modular
        
        return services;
    }
}