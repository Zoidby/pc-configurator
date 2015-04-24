using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Memory : MongoEntity
    {
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("model")]
        [BsonRequired]
        public string Model { get; set; }

        [BsonElement("capacity")]
        [BsonRequired]
        public string Capacity { get; set; }

        [BsonElement("cl")]
        public string CasLatency { get; set; }

        [BsonElement("voltage")]
        public string Voltage { get; set; }

        [BsonElement("type")]
        [BsonRequired]
        public string Type { get; set; }

        [BsonElement("speed")]
        [BsonRequired]
        public string Speed { get; set; }

        [BsonElement("features")]
        public string Features { get; set; }
    }
}