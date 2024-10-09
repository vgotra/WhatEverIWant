using WhatEverIWant.Configuration;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddMappers(); // If needed

var app = builder.Build();
app.Run();
