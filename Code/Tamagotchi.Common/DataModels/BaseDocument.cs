using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Tamagotchi.Common.DataModels
{
    public class BaseDocument
    {
        [BsonRequired]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonRequired]
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }
        [BsonRequired]
        [BsonElement("lastModified")]
        public DateTime LastModified { get; set; }
    }
}
