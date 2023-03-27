using MongoDB.Driver;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Mongo.Indexes
{
    public static class CollectionIndex
    {
        public static void CreateIndexIfRequired<T>(IMongoCollection<T> collection)
        {
            if(typeof(T) == typeof(Bar))
            {
                SetUniqueCompositeIndexForBarCollection((IMongoCollection<Bar>)collection);
            }
        }

        private static void SetUniqueCompositeIndexForBarCollection(IMongoCollection<Bar> collection)
        {
            var indexModel = new CreateIndexModel<Bar>(
             new IndexKeysDefinitionBuilder<Bar>()
                .Ascending(x => x.Instrument.Name)
                .Ascending(x => x.Aggregation.Type)
                .Ascending(x => x.Aggregation.Value)
                .Ascending(x => x.BarInfo.Time),
             new CreateIndexOptions() { Name = "ContentUniqueIndex", Unique = true });

            collection.Indexes.CreateOne(indexModel);
        }
    }
}
