using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBExemplo.Domain.Abstractions.Attributes;
using MongoDBExemplo.Domain.Abstractions.Helpers;
using MongoDBExemplo.Domain.Interfaces.Repositories;
using System;

namespace MongoDBExemplo.Domain.Models
{
    [BsonCollection("ASSET")]
    public class AssetModel : IDocument
    {
        public AssetModel(string id, string ticker, string name, decimal price)
        {
            Id = id;
            Ticker = ticker;
            Name = name;
            Price = price;
            CreatedDate = DateTime.Now;
            CreatedBy = CreatorHelper.GetCreatorBy();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TICKER")]
        public string Ticker { get; set; }

        [BsonElement("NAME")]
        public string Name { get; set; }

        [BsonElement("PRICE")]
        public decimal Price { get; set; }

        [BsonElement("CREATED_DT")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("CREATED_USER")]
        public string CreatedBy { get; set; }
    }
}