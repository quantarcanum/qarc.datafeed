using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Qarc.DataFeed.Adapter.Mongo.Repository;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.SharedKernel;
using Qarc.DataFeed.Adapter.Mongo.ConfigSettings;
using Qarc.DataFeed.Adapter.Mongo.FluentApi;
using Qarc.DataFeed.Adapter.Mongo.Indexes;

namespace Qarc.DataFeed.Adapter.Mongo.Bootstrapper
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddMongoServices(this IServiceCollection services)
        {
            BsonClassMapper.MapAll();

            services.AddSingleton<IMongoSettingsManager, MongoSettingsManager>();

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddSingleton(serviceProvider =>
            {
                
                var mongoConfig = serviceProvider.GetService<IMongoSettingsManager>();
                var mongoClient = new MongoClient(mongoConfig.ConnectionString);
                return mongoClient.GetDatabase(mongoConfig.ServiceDbName);
            });

            return services;
        }

        public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collectionName) where T : IEntity
        {
            services.AddSingleton<IRepository<T>>(serviceProvider =>
            {
                var database = serviceProvider.GetService<IMongoDatabase>();

                return new MongoRepository<T>(database, collectionName);
            });
            return services;
        }
    }
}
