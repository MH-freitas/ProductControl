using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Core.Types;
using ProductControl.Controllers;
using ProductControl.Data;
using ProductControl.Data.Repositories;
using ProductControl.Interfaces.Repositories;
using ProductControl.Interfaces.Services;
using ProductControl.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IProductRepositorie, RepositoryProduct>();
builder.Services.AddScoped<IBeautyProduct, BeautyDiscount>();
builder.Services.AddScoped<IClothingProduct, ClothingDiscount>();
builder.Services.AddScoped<IElectronicsProduct, ElectronicDiscount>();
builder.Services.AddScoped<IFoodProduct, FoodDiscount>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure Swagger

app.Run();


