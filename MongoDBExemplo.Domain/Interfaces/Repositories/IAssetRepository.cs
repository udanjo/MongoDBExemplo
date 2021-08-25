using MongoDBExemplo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBExemplo.Domain.Interfaces.Repositories
{
    public interface IAssetRepository
    {
        Task SaveAsset(AssetModel model);
        Task<IEnumerable<AssetModel>> GetAll();
        Task<IEnumerable<AssetModel>> Get(string ticker);
        Task<bool> Delete(string ticker);
    }
}