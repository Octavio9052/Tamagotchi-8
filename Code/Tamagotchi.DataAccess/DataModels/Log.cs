using MongoDB.Bson.Serialization.Attributes;

namespace Tamagotchi.DataAccess.DataModels
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
