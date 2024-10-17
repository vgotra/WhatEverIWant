using WhatEverIWant.BusinessLogic.ExternalMetadataServices.Omdb;

namespace WhatEverIWant.Api.Configuration;

public static class MetadataServicesConfiguration
{
    public static IServiceCollection AddMetadataServices(this IServiceCollection services, IHostApplicationBuilder context)
    {
        services.Configure<OmdbServiceSettings>(context.Configuration.GetSection("OmdbServiceSettings")); //TODO Move to db later
        services.AddScoped<IOmdbService, OmdbService>();

        return services;
    }
}