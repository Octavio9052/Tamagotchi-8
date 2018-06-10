using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class LogDAL : BaseMongoDAL<Log>, ILogMongoDAL
    {
        
        public LogDAL(TamagotchiMongoClient client) : base(client, "log")
        {
        }

        public ICollection<Log> AddLogs(Log log)
        {
            Collection.InsertOne(log);

            return Collection.FindSync<Log>(new BsonDocument()).ToList();
        }

        public ICollection<Log> LoadLogs(int animalId)
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
