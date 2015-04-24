using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Psu : MongoEntity
    {
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("model")]
        [BsonRequired]
        public string Model { get; set; }

        [BsonElement("type")]
        [BsonRequired]
        public string Type { get; set; }

        [BsonElement("power")]
        [BsonRequired]
        public string MaximumPower { get; set; }

        [BsonElement("efficiency")]
        [BsonRequired]
        public string Efficiency { get; set; }

        [BsonElement("features")]
        public string Features { get; set; }
    }
}