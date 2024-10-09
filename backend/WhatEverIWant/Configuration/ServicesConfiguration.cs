using WhatEverIWant.Services;

namespace WhatEverIWant.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            
        // Register Specific Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ISeriesService, SeriesService>();
        services.AddScoped<IMusicService, MusicService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAudioBookService, AudioBookService>();

        return services;
    }
}