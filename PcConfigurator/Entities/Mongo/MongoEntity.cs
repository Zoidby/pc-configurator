using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}