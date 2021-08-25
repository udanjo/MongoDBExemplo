using MongoDBExemplo.Domain.Interfaces.Repositories;

namespace MongoDBExemplo.Domain.Abstractions.Models
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}