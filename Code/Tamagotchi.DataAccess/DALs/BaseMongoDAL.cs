using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.DataAccess.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseMongoDAL<T> : IBaseMongoDAL<T> where T : BaseDocument
    {
        private const string CONNECTION_STRING = "mongodb://localhost";
        private const string MONGO_DB = "tamagotchi-009052";
        protected IMongoDatabase _dbMongo;

        public BaseMongoDAL()
        {
            this._dbMongo = new MongoClient(CONNECTION_STRING).GetDatabase(MONGO_DB);
        }

        public T Create(T document)
        {
            document.DateCreated = DateTime.Now;
            document.LastModified = DateTime.Now;
            this._dbMongo.GetCollection<T>(document.ToString()).InsertOne(document);
            return document;
        }

        public void Delete(int id, string collectionName)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            this._dbMongo.GetCollection<T>(collectionName).DeleteOne(filter);
        }

        public T Get(string id, string collectionName)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            return this._dbMongo.GetCollection<T>(collectionName).Find(filter).Single<T>();
        }

        public ICollection<T> GetAll(string collectionName)
        {
            return this._dbMongo.GetCollection<T>(collectionName).Find(new BsonDocument()).ToList<T>();
        }

        public T Update(T document)
        {
            var filter = Builders<T>.Filter.Eq("id", document.Id);
            return this._dbMongo.GetCollection<T>(document.ToString()).FindOneAndReplace(filter, document);
        }
    }
}
