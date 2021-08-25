using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AssetService> _logger;

        public AssetService(IAssetRepository repository,
                            ILogger<AssetService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> SaveAsset(AssetModel model)
        {
            try
            {
                _logger.LogInformation("Chamada via service para gravar a informação");

                await _repository.SaveAsset(model);
                
                _logger.LogInformation("Infomação salva com sucesso");
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao salvar via service", ex);
                throw;
            }
        }

        public async Task<IEnumerable<AssetModel>> GetAsset(string ticker)
        {
            try
            {
                return await _repository.Get(string.IsNullOrEmpty(ticker) ? null : ticker.ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao buscar Asset via service", ex);
                throw;
            }
        }

        public async Task<bool> DeleteAsset(string ticker)
        {
            try
            {
                return await _repository.Delete(ticker.ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao deletar {ticker} via service", ex);
                throw;
            }
        }
    }
}