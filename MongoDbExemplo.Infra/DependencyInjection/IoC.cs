using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDbExemplo.Infra.Repositories;
using MongoDBExemplo.Domain.Abstractions.Models;
using MongoDBExemplo.Domain.Interfaces.Repositories;
using MongoDBExemplo.Domain.Interfaces.Services;
using MongoDBExemplo.Domain.Services;

namespace MongoDbExemplo.Infra.DependencyInjection
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            //Domain
            services.AddScoped<IAssetService, AssetService>();

            //Mongo
            var mongoConnectionString = configuration.GetSection("MongoDbConfig:ConnectionString").Value;
            var mongoDatabase = configuration.GetSection("MongoDbConfig:Database").Value;

            var mongoConfig = new MongoDbSettings
            {
                ConnectionString = mongoConnectionString,
                Database = mongoDatabase
            };

            //Repository
            services.AddSingleton<IMongoDbSettings>(_ => mongoConfig);
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IAssetRepository, AssetRepository>();

            return services;
        }
    }
}