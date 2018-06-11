using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class PetDAL : BaseMongoDAL<Pet>, IPetDAL
    {
        
        public PetDAL(TamagotchiMongoClient client) : base(client, "Pet")
        {
        }
        
        public ICollection<Pet> GetByAnimal(int animalId)
        {
            var filter = Builders<Pet>.Filter.Eq("animalId", animalId);
            return Collection.Find(new BsonDocument()).ToList();
        }

        public ICollection<Pet> GetByUser(int userId)
        {
            var filter = Builders<Pet>.Filter.Eq("ownerId", userId);
            return Collection.Find(new BsonDocument()).ToList();
        }

    }
}
