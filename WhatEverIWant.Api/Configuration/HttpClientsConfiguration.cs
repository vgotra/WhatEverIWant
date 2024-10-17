namespace WhatEverIWant.Api.Configuration;

public static class HttpClientsConfiguration
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient("OMDB", client => client.BaseAddress = new Uri("http://www.omdbapi.com"));
        
        return services;
    }
}