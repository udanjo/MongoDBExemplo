using MongoDBExemplo.Domain.Interfaces.Repositories;
using MongoDBExemplo.Domain.Interfaces.Services;
using MongoDBExemplo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBExemplo.Domain.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> InsertAsset(AssetModel model)
        {
            try
            {
                await _repository.SaveAsset(model);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AssetModel>> GetAsset(string ticker)
        {
            try
            {
                return await _repository.Get(string.IsNullOrEmpty(ticker) ? null : ticker.ToUpper());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsset(string ticker)
        {
            try
            {
                return await _repository.Delete(ticker.ToUpper());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}