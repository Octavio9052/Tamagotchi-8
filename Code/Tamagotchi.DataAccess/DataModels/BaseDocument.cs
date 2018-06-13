using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Tamagotchi.DataAccess.DataModels
{
    public class BaseDocument : IBaseEntity
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonRequired]
        [BsonElement("dateCreated")]
        public DateTime DateCreated { get; set; }
        [BsonRequired]
        [BsonElement("lastModified")]
        public DateTime LastModified { get; set; }
    }
}
