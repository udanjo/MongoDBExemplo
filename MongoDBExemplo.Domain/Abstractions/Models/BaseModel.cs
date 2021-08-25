using MongoDBExemplo.Domain.Abstractions.Helpers;
using System;

namespace MongoDBExemplo.Domain.Abstractions.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        protected void SetModelDefault()
        {
            CreatedDate = DateTime.Now;
            CreatedBy = CreatorHelper.GetCreatorBy();
        }
    }
}