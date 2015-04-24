using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Cpu : MongoEntity
    {
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("model")]
        [BsonRequired]
        public string Model { get; set; }

        [BsonElement("series")]
        [BsonRequired]
        public string Series { get; set; }

        [BsonElement("socket")]
        [BsonRequired]
        public string Socket { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("core_name")]
        public string CoreName { get; set; }

        [BsonElement("cores_count")]
        public int CoresCount { get; set; }

        [BsonElement("frequency")]
        public string Frequency { get; set; }

        [BsonElement("tdp")]
        public string Tdp { get; set; }

        [BsonElement("graphics")]
        public string Graphics { get; set; }

        [BsonElement("voltage")]
        public string Voltage { get; set; }
    }
}