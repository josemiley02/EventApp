using System;
using System.Linq.Expressions;
using EventApp.Application.Interfaces;
using EventApp.Infrastructure.Persistence;
using MongoDB.Driver;

namespace EventApp.Infrastructure.Repositories;

public class MongoRepository<T> : IGenericRepository<T> where T : class
{
    private IMongoCollection<T> _collection;
    public MongoRepository(MongoDbContext context)
    {
        _collection = context._database.GetCollection<T>(typeof(T).Name);
    }
    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllFilteredAsync(params Expression<Func<T, bool>>[] filters)
    {
        var filter = Builders<T>.Filter.Empty;

        foreach (var expr in filters)
        {
            filter &= Builders<T>.Filter.Where(expr);
        }

        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(string id, T entity)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await _collection.ReplaceOneAsync(filter, entity);
    }
}
