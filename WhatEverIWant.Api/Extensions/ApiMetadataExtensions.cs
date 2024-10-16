namespace WhatEverIWant.Api.Extensions;

public static class ApiMetadataExtensions
{
    public static RouteHandlerBuilder WithEndpointMetadata(this RouteHandlerBuilder builder, string name, string description) => builder.WithName(name).WithDescription(description);

    public static RouteHandlerBuilder Produces(this RouteHandlerBuilder builder, params int[] statusCodes)
    {
        foreach (var code in statusCodes)
            OpenApiRouteHandlerBuilderExtensions.Produces(builder, code);

        return builder;
    }
}