using WhatEverIWant.Api.Api;
using WhatEverIWant.Api.Api.Metadata;

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

        app.MapExternalMetadataApi();
        
        return app;
    }
}