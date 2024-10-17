namespace WhatEverIWant.Api.Extensions;

public static class ApiResultsExtensions
{
    public static async Task<IResult> OkAsync<T>(this Task<T> task)
    {
        var result = await task;
        return TypedResults.Ok(result);
    }
    
    public static async Task<IResult> OkOrNotFoundAsync<T>(this Task<T> task)
    {
        var result = await task;
        return result != null ? TypedResults.Ok(result) : Results.NotFound();
    }
    
    public static async Task<IResult> CreatedAsync<TResponse>(this Task<TResponse> task, Func<TResponse, string?> uri)
    {
        var result = await task;
        return Results.Created(uri(result), result);
    }
    
    public static async Task<IResult> NoContentOrNoFoundAsync(this Task<bool> task)
    {
        var result = await task;
        return result ? Results.NoContent() : Results.NotFound();
    }
    
    public static async Task<IResult> NoContentOrNoFoundAsync<T>(this Task<T> task, Func<T, bool> condition)
    {
        var result = await task;
        return condition(result) ? Results.NoContent() : Results.NotFound();
    }
}