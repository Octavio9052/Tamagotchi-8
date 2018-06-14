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
        public string AnimalId { get; set; }
        [BsonElement("animalName")]
        public string AnimalName { get; set; }

        [BsonElement("userId")]
        [BsonRequired]
        public string UserId { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("petId")]
        public string PetId { get; set; }
        [BsonElement("petName")]
        public string PetName { get; set; }

        public override string ToString()
        {
            return "Log";
        }
    }
}
