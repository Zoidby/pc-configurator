using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Motherboard : MongoEntity
    {
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("model")]
        [BsonRequired]
        public string Model { get; set; }

        [BsonElement("cpu_socekt")]
        [BsonRequired]
        public string CpuSocket { get; set; }

        [BsonElement("cpu_type")]
        public string CpuType { get; set; }

        [BsonElement("memory_max")]
        [BsonRequired]
        public string MemoryMaximum { get; set; }

        [BsonElement("memory_slots")]
        [BsonRequired]
        public string MemorySlots { get; set; }

        [BsonElement("features")]
        public string Features { get; set; }
    }
}