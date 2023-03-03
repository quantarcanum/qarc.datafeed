using MongoDB.Driver;
using Qarc.DataFeed.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qarc.DataFeed.Adapter.Mongo.Indexes
{
    public static class CollectionIndex
    {
        public static void CreateIndexIfRequired<T>(IMongoCollection<T> collection)
        {
            if(typeof(T) == typeof(GuerrillaTrendRevBar))
            {
                SetUniqueCompositeIndexForGuerrillaTrendRevBarCollection((IMongoCollection<GuerrillaTrendRevBar>)collection);
            }
        }

        private static void SetUniqueCompositeIndexForGuerrillaTrendRevBarCollection(IMongoCollection<GuerrillaTrendRevBar> collection)
        {
            var indexModel = new CreateIndexModel<GuerrillaTrendRevBar>(
             new IndexKeysDefinitionBuilder<GuerrillaTrendRevBar>()
                .Ascending(x => x.Instrument)
                .Ascending(x => x.TrendTicks)
                .Ascending(x => x.ReversalTicks)
                .Ascending(x => x.Time),
             new CreateIndexOptions() { Name = "ContentUniqueIndex", Unique = true });

            collection.Indexes.CreateOne(indexModel);
        }
    }
}
