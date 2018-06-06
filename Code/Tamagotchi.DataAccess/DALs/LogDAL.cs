using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class LogDAL : BaseMongoDAL<Log>, ILogMongoDAL
    {
        public ICollection<Log> AddLogs(Log log)
        {
            this._dbMongo.GetCollection<Log>("Log")
                .InsertOne(log);

            return this._dbMongo.GetCollection<Log>("Log")
                .FindSync<Log>(new BsonDocument())
                .ToList<Log>();

        }

        public ICollection<Log> LoadLogs(int animalId)
        {
            this._dbMongo.GetCollection<Log>("Log")
                .FindSync<Log>(new BsonDocument())
                .ToList<Log>();

            var builder = Builders<Log>.Filter;
            var filter = builder.Eq("AnimalId", animalId);

            return this._dbMongo.GetCollection<Log>("Log")
                .Find(filter).ToList<Log>();
        }

        public override string ToString()
        {
            return "Log";
        }
    }
}
