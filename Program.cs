using FluentValidation;
using FluentValidation.AspNetCore;
using ProyectoInventario.repositories;
using ProyectoInventario.services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();


builder.Services.AddSingleton<ICategoriaRepository, InMemoryCategoriaRepository>();

builder.Services.AddSingleton<IInventarioRepository, InMemoryInventarioRepository>();

builder.Services.AddSingleton<IOrdenCompraRepository, InMemoryOrdenCompraRepository>();

builder.Services.AddSingleton<IProductoRepository, InMemoryProductoRepository>();

builder.Services.AddSingleton<IProveedorRepository, InMemoryProveedorRepository>();

builder.Services.AddSingleton<IUsuarioRepository, InMemoryUsuarioRepository>();

builder.Services.AddSingleton<IVentaRepository, InMemoryVentaRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
