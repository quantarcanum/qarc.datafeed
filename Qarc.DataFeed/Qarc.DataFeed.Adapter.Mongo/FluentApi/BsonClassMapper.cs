using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Mongo.FluentApi
{
    public static class BsonClassMapper
    {
        public static void MapAll()
        {
            MapGuerrillaTrendRevBar();
        }

        public static void MapGuerrillaTrendRevBar()
        {
            BsonClassMap.RegisterClassMap<GuerrillaTrendRevBar>(cm =>
            {
                cm.AutoMap(); //use this first, then override specific props

                cm.MapIdMember(c => c.Id)
                    .SetIdGenerator(new StringObjectIdGenerator())
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetElementName("id");

                cm.SetIgnoreExtraElements(true); // no exception if more props come from json then the model has

                //cm.MapProperty(p => p.Instrument).SetElementName("instrument");
                //cm.MapProperty(p => p.Exchange);
                //cm.MapProperty(p => p.TrendTicks);
                //cm.MapProperty(p => p.ReversalTicks);
                //cm.MapProperty(p => p.Time);


                //cm.UnmapMember(c => c.SomeProperty);
                //cm.MapMember(c => c.FavoriteColor).SetSerializer(new EnumSerializer<Color>(BsonType.String));
            });
        }

    }
}
