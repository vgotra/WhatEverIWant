using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.BusinessLogic.Mappers.Services;
using WhatEverIWant.BusinessLogic.Mappers.Services.Metadata;
using WhatEverIWant.BusinessLogic.Models.Api.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Api.Books;
using WhatEverIWant.BusinessLogic.Models.Api.Movies;
using WhatEverIWant.BusinessLogic.Models.Api.Music;
using WhatEverIWant.BusinessLogic.Models.Api.TvShows;
using AudioBookMapper = WhatEverIWant.BusinessLogic.Mappers.Services.AudioBookMapper;
using BookMapper = WhatEverIWant.BusinessLogic.Mappers.Services.BookMapper;
using MovieMapper = WhatEverIWant.BusinessLogic.Mappers.Services.MovieMapper;
using MusicMapper = WhatEverIWant.BusinessLogic.Mappers.Services.MusicMapper;
using OmdbResponseMapper = WhatEverIWant.BusinessLogic.Mappers.Services.Metadata.OmdbResponseMapper;
using TvShowsMapper = WhatEverIWant.BusinessLogic.Mappers.Services.TvShowsMapper;

namespace WhatEverIWant.Api.Configuration;

public static class MapperConfiguration
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        // Mapperly generates and registers mapper implementations automatically
        // No explicit registration needed unless custom behavior is required

        services.AddScoped<IGenericMapper<CreateMovieRequest, UpdateMovieRequest, MovieResponse, Movie>, MovieMapper>();
        services.AddScoped<IGenericMapper<CreateTvShowRequest, UpdateTvShowRequest, TvShowResponse, TvShow>, TvShowsMapper>();
        services.AddScoped<IGenericMapper<CreateMusicRequest, UpdateMusicRequest, MusicResponse, Music>, MusicMapper>();
        services.AddScoped<IGenericMapper<CreateBookRequest, UpdateBookRequest, BookResponse, Book>, BookMapper>();
        services.AddScoped<IGenericMapper<CreateAudioBookRequest, UpdateAudioBookRequest, AudioBookResponse, AudioBook>, AudioBookMapper>();
        
        services.AddScoped<IOmdbResponseMapper, OmdbResponseMapper>(); //TODO Move to metadata mapper or make modular
        
        return services;
    }
}