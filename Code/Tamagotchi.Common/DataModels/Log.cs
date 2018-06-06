using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace Tamagotchi.Common.DataModels
{
    public class Log : BaseDocument
    {
        [BsonElement("message")]
        [BsonRequired]
        public string Message { get; set; }
        [BsonElement("animalId")]
        [BsonRequired]
        public int AnimalId { get; set; }
        [BsonElement("userId")]
        [BsonRequired]
        public int UserId { get; set; }

        public override string ToString()
        {
            return "Log";
        }
    }
}
