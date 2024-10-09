using WhatEverIWant.DataAccess.Repositories;

namespace WhatEverIWant.Configuration;

public static class RepositoriesConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Optionally, register the generic repository if needed elsewhere
        // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        // Register Specific Repositories
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ISeriesRepository, SeriesRepository>();
        services.AddScoped<IMusicRepository, MusicRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAudioBookRepository, AudioBookRepository>();

        return services;
    }
}