using WhatEverIWant.DataAccess.Entities;
using WhatEverIWant.BusinessLogic.Mappers;
using WhatEverIWant.BusinessLogic.Models.AudioBooks;
using WhatEverIWant.BusinessLogic.Models.Books;
using WhatEverIWant.BusinessLogic.Models.Movies;
using WhatEverIWant.BusinessLogic.Models.Music;
using WhatEverIWant.BusinessLogic.Models.Series;

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
        
        return services;
    }
}