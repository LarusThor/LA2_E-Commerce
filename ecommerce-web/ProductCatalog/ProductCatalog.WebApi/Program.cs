using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories.Data;
using ProductCatalog.Repositories.Implementations;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.Services.Implementations;
using ProductCatalog.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductCatalogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProductCatalogConnection")));

builder.Services.AddOpenApi();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();