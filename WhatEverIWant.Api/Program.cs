using WhatEverIWant.Api.Configuration;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddMappers();
builder.Services.AddHttpClients();
builder.Services.AddMetadataServices(builder);

builder.Services.AddDbContext(builder);

var app = builder.Build();
app.MapApi();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().CacheOutput();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
    app.UseReDoc(options => options.SpecUrl("/openapi/v1.json"));
    
    // For Testing Purposes
    /*
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    */
}

app.Run();