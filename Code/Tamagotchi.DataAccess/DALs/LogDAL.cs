using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class LogDAL : BaseMongoDAL<Log>, ILogDAL
    {
        
        public LogDAL(TamagotchiMongoClient client) : base(client, "log")
        {
        }

        public ICollection<Log> AddLogs(Log log)
        {
            Collection.InsertOne(log);

            return Collection.FindSync<Log>(new BsonDocument()).ToList();
        }

        public ICollection<Log> LoadLogs(string animalId)
        {
            Collection
                .FindSync<Log>(new BsonDocument())
                .ToList();

            var builder = Builders<Log>.Filter;
            var filter = builder.Eq("AnimalId", animalId);

            return Collection.Find(filter).ToList();
        }

 
    }
}
