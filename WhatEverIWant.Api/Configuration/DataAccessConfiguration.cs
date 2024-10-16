using Microsoft.EntityFrameworkCore;
using WhatEverIWant.DataAccess;

namespace WhatEverIWant.Api.Configuration;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IHostApplicationBuilder context)
    {
        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseSqlite(context.Configuration.GetConnectionString("Default")));

        return services;
    }
}