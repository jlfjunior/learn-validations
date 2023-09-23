using Microsoft.AspNetCore.Mvc;
using Nursey.API.Entities;
using Nursey.API.Repositories;
using Nursey.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<PersonRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("status", () => {
    return Results.Ok("Running...");
});

app.MapPost("people/parents", (PersonRequest parent) => {
    return Results.Ok($"Parent registered successfully. Id: {parent.CPF}");
});

app.MapPost("people/children", (ChildRequest child) => {
    return Results.Ok($"Parent registered successfully. Id: {child.CPF}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
