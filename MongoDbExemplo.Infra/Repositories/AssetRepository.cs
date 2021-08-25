using MongoDBExemplo.Domain.Interfaces.Repositories;
using MongoDBExemplo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbExemplo.Infra.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IMongoRepository<AssetModel> _repository;

        public AssetRepository(IMongoRepository<AssetModel> repository)
        {
            _repository = repository;
        }

        public async Task SaveAsset(AssetModel model)
        {
            try
            {
                await _repository.SaveAsync(model, x => x.Ticker == model.Ticker);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AssetModel>> GetAll()
        {
            try
            {
                return await _repository.GetAsync(null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AssetModel>> Get(string ticker)
        {
            try
            {
                if (ticker == null)
                {
                    return await _repository.GetAsync(null);
                }
                else
                {
                    return await _repository.GetAsync(x => x.Ticker == ticker);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string ticker)
        {
            try
            {
                return await _repository.DeleteAsync(x => x.Ticker == ticker);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}