using System;

namespace MongoDBExemplo.Domain.Interfaces.Repositories
{
    public interface IDocument
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}