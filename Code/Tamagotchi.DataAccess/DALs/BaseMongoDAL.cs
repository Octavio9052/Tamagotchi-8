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
using MongoDB.Bson.Serialization;

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
            RegisterMapIfNeeded<T>();
        }



        // Check to see if map is registered before registering class map
        // This is for the sake of the polymorphic types that we are using so Mongo knows how to deserialize
        public void RegisterMapIfNeeded<TClass>()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TClass)))
                BsonClassMap.RegisterClassMap<TClass>();
        }

        public T Create(T document)
        {
            document.DateCreated = DateTime.Now;
            document.LastModified = DateTime.Now;
            this._dbMongo.GetCollection<T>(document.ToString()).InsertOne(document);
            return document;
        }

        public void Delete(string id, string collectionName)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            this._dbMongo.GetCollection<T>(collectionName).DeleteOne(filter);
        }

        public T Get(string id, string collectionName)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var test = this._dbMongo.GetCollection<T>(collectionName).Find(filter).FirstOrDefault();
            return test;
        }

        public ICollection<T> GetAll(string collectionName)
        {
            return this._dbMongo.GetCollection<T>(collectionName).Find(new BsonDocument()).ToList();
        }

        public T Update(T document)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(document.Id));
            return this._dbMongo.GetCollection<T>(document.ToString()).FindOneAndReplace<T>(filter, document);
        }
    }
}
