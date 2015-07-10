using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using PlayingWithMongoDB.Extensions;

namespace PlayingWithMongoDB
{
    public class Db<T> : IDb<T> where T : Entity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoDatabase _database;

        public Db(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentException("Missing MongoDB connection string");
            }

            var client = new MongoClient(connectionString);
            var mongoUrl = MongoUrl.Create(connectionString);

            _database = client.GetDatabase(mongoUrl.DatabaseName);
            _collection = _database.GetCollection<T>(this.BuildCollectionName());
        }

        public IMongoCollection<T> Collection
        {
            get { return _collection; }
        }

        public async Task<T> GetById(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
            return entity;
        }
    }
}