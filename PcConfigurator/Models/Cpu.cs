using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace PcConfigurator.Models
{
    public class Cpu
    {
        public ObjectId Id { get; set; }
        [BsonElement("number")]
        public string Number { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        [BsonElement("socket")]
        public string Socket { get; set; }
    }
}