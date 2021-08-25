using MongoDBExemplo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBExemplo.Domain.Interfaces.Services
{
    public interface IAssetService
    {
        Task<bool> SaveAsset(AssetModel model);
        Task<IEnumerable<AssetModel>> GetAsset(string ticker);
        Task<bool> DeleteAsset(string ticker);
    }
}