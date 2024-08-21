using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Infra.Repositories.Notam.v1;
using Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Text.Json;

namespace Infra
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfraContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongo");
            var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(clientSettings);

            BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.LocalInstance);

            return services
                .AddSingleton(clientSettings)
                .AddSingleton<IMongoClient>(client)
                .AddScoped(typeof(IRepository<,>), typeof(BaseDbRepository<,>))
                .AddScoped<INotamRepository, NotamRepository>();
        }
    }
}