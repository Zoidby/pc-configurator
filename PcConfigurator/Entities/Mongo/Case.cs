using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace PcConfigurator.Entities.Mongo
{
    public class Case : MongoEntity
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

        [BsonElement("mbCompatibility")]
        [BsonRequired]
        public List<String> MotherBoardCompatibility { get; set; }

        [BsonElement("features")]
        public string Features { get; set; }
    }
}