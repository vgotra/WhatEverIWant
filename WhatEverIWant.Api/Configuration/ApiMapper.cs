using WhatEverIWant.Api.Api;

namespace WhatEverIWant.Api.Configuration;

public static class ApiMapper
{
    public static WebApplication MapApi(this WebApplication app)
    {
        app.MapAudioBooksApi();
        app.MapMoviesApi();
        app.MapMusicApi();
        app.MapSeriesApi();
        app.MapBooksApi();
        
        return app;
    }
}