using MongoDBExemplo.Domain.Models;

namespace MongoDBExemplo.WebApi.Request
{
    public record AssetRequest
    {
        public string Id { get; set; }
        public string Ticker { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public AssetModel ToDomain() => new(Id, Ticker.ToUpper(), Name.ToUpper(), Price);
    }
}