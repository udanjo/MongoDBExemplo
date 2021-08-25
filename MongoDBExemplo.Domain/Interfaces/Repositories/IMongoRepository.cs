using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDBExemplo.Domain.Interfaces.Repositories
{
    public interface IMongoRepository<T> where T : IDocument
    {
        Task SaveAsync(T document, Expression<Func<T, bool>> filter);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
    }
}