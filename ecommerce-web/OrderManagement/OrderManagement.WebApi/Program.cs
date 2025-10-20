using Microsoft.EntityFrameworkCore;
using OrderManagement.Repositories.Data;
using OrderManagement.Repositories.Implementations;
using OrderManagement.Repositories.Interfaces;
using OrderManagement.Services.Implementations;
using OrderManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

// Connection string is not ProductCatalogConnection 
builder.Services.AddDbContext<OrderManagementDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OrderManagementConnection")));

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

