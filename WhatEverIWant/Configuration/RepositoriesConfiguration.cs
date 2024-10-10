using WhatEverIWant.DataAccess.Repositories;

namespace WhatEverIWant.Configuration;

public static class RepositoriesConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ISeriesRepository, SeriesRepository>();
        services.AddScoped<IMusicRepository, MusicRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAudioBookRepository, AudioBookRepository>();

        return services;
    }
}