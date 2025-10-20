using Microsoft.EntityFrameworkCore;
using OrderManagement.Repositories.Data;
using OrderManagement.Repositories.Implementations;
using OrderManagement.Repositories.Interfaces;
using OrderManagement.Services.Implementations;
using OrderManagement.Services.Interfaces;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<OrderManagementDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OrderManagementConnection")));

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddHttpClient<IOrdersRepository, OrdersRepository>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth0:Domain"];
        options.Audience = builder.Configuration["Auth0:Audience"];
    });

builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

