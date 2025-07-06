using EventApp.Shared.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using EventApp.Infrastructure.Persistence;
using EventApp.Application.Interfaces;
using EventApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddScoped<MongoDbContext>();

// Si usas una interfaz genérica:
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(MongoRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();