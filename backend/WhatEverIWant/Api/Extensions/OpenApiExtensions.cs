using Microsoft.OpenApi.Models;

namespace WhatEverIWant.Api.Extensions;

public static class OpenApiExtensions
{
    public static OpenApiOperation WithDescription(this OpenApiOperation operation, string description)
    {
        operation.Description = description;
        return operation;
    }
}