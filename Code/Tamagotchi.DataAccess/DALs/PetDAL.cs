using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class PetDAL : BaseMongoDAL<Pet>, IPetMongoDAL
    {
        
        public PetDAL(TamagotchiMongoClient client) : base(client, "pet")
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
