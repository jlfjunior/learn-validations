using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nursey.API.Entities;
using Nursey.API.Repositories;
using Nursey.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<IValidator<PersonRequest>, PersonRequestValidatorSmart>();

builder.Services.AddDbContext<Context>(options 
    => options.UseInMemoryDatabase("Memory"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("people", (PersonRepository repository) => {
    return Results.Ok(repository.GetAll());
});

app.MapPost("people/parents", (PersonRequest parent, RegisterService service, IValidator<PersonRequest> smart) => {
    var validator = new PersonRequestValidator().Validate(parent);
    var validatorSmart = smart.Validate(parent);
    if (!service.AddParent(parent))
        return Results.BadRequest("Parent has been registered already.");

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
