using Microsoft.EntityFrameworkCore;
using WhatEverIWant.Configuration;
using WhatEverIWant.DataAccess;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddMappers(); // If needed

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

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