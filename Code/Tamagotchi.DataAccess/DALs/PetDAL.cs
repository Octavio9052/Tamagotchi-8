using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Tamagotchi.DataAccess.DALs
{
    public class PetDAL : BaseMongoDAL<Pet>, IPetMongoDAL
    {
        public ICollection<Pet> GetByAnimal(int animalId)
        {
            var filter = Builders<Pet>.Filter.Eq("animalId", animalId);
            return this._dbMongo.GetCollection<Pet>("Pet").Find(new BsonDocument()).ToList<Pet>();
        }

        public ICollection<Pet> GetByUser(int userId)
        {
            var filter = Builders<Pet>.Filter.Eq("ownerId", userId);
            return this._dbMongo.GetCollection<Pet>("Pet").Find(new BsonDocument()).ToList<Pet>();
        }
    }
}
