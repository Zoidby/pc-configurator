using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Gpu : MongoEntity
    {
        [BsonElement("brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("model")]
        [BsonRequired]
        public string Model { get; set; }

        [BsonElement("interface")]
        [BsonRequired]
        public string Interface { get; set; }

        [BsonElement("chipset_manufacturer")]
        [BsonRequired]
        public string ChipsetManufacturer { get; set; }

        [BsonElement("gpu_model")]
        [BsonRequired]
        public string GpuModel { get; set; }
    }
}