using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DBContext;
using ProductManagementSystem.Services;
using ProductManagementSystem.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductManagementSystemDbContext>
         (o => o.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementSystemDb")));
builder.Services.AddSingleton<ICategoryDataAccess, CategoryDataAccess>();
builder.Services.AddSingleton<IProductDataAccess, ProductDataAccess>();
builder.Services.AddSingleton<IOrderDataAccess, OrderDataAccess>();
builder.Services.AddSingleton<IOrderProductDataAccess, OrderProductDataAccess>();
builder.Services.AddSingleton<IService, Service>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
