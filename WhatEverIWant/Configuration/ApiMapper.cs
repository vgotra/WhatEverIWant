using WhatEverIWant.Api;

namespace WhatEverIWant.Configuration;

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