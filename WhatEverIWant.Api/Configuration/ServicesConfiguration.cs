using WhatEverIWant.BusinessLogic.Services;
using WhatEverIWant.Common;

namespace WhatEverIWant.Api.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ISnowflakeIdGenerator, SnowflakeIdGenerator>();
        
        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<ITvShowsService, TvShowsService>();
        services.AddScoped<IMusicService, MusicService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAudioBookService, AudioBookService>();
      
        return services;
    }
}