using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExemplo.Domain.Abstractions.Attributes;
using MongoDBExemplo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDbExemplo.Infra.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IDocument
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDbSettings dbSettings)
        {
            var database = new MongoClient(dbSettings.ConnectionString).GetDatabase(dbSettings.Database);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        public async virtual Task SaveAsync(T document, Expression<Func<T, bool>> filter)
        {
            var response = await FindOneAsync(filter);

            if (response != null)
            {
                await _collection.ReplaceOneAsync(filter, document);
                return;
            }

            await _collection.InsertOneAsync(document);
        }

        public async virtual Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            var documents = filter != null ? _collection.Find(filter) : _collection.Find(new BsonDocument());
            return await documents.ToListAsync();
        }

        public virtual Task<T> FindOneAsync(Expression<Func<T, bool>> filter) => Task.Run(() => _collection.Find(filter).FirstOrDefaultAsync());

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var resul = await _collection.DeleteOneAsync(filter);
            return resul.DeletedCount > 0;
        }

        private protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute)type
                    .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                    .FirstOrDefault())?.CollectionName;
        }
    }
}