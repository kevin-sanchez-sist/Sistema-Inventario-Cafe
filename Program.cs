using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProyectoInventario.repositories;
using ProyectoInventario.services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();


builder.Services.AddSingleton<ICategoriaRepository, InMemoryCategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddSingleton<IInventarioRepository, InMemoryInventarioRepository>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

builder.Services.AddSingleton<IOrdenCompraRepository, InMemoryOrdenCompraRepository>();
builder.Services.AddScoped<IOrdenCompraService, OrdenCompraService>();

builder.Services.AddSingleton<IProductoRepository, InMemoryProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

builder.Services.AddSingleton<IProveedorRepository, InMemoryProveedorRepository>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

builder.Services.AddSingleton<IUsuarioRepository, InMemoryUsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddSingleton<IVentaRepository, InMemoryVentaRepository>();
builder.Services.AddScoped<IVentaService, VentaService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
