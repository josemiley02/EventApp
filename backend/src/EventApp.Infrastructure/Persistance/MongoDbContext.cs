using MongoDB.Driver;
using EventApp.Shared.Settings;
using Microsoft.Extensions.Options;
using EventApp.Application.Interfaces;
using EventApp.Infrastructure.Repositories;

namespace EventApp.Infrastructure.Persistence;

public class MongoDbContext
{
    public readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoSettings> settings, IMongoClient client)
    {
        _database = client.GetDatabase(settings.Value.Database);
    }

    public IGenericRepository<T> GetCollection<T>(string name) where T : class
    {
        return new MongoRepository<T>(this);
    }
}
