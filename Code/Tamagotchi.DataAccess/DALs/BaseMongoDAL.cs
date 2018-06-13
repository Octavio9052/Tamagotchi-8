using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseMongoDAL<T> : IBaseDAL<T> where T : BaseDocument
    {
        protected readonly IMongoCollection<T> Collection;

        protected BaseMongoDAL(TamagotchiMongoClient client, string collectionName)
        {
            Collection = client.Database.GetCollection<T>(collectionName);
            RegisterMapIfNeeded<T>();
        }

        // Check to see if map is registered before registering class map
        // This is for the sake of the polymorphic types that we are using so Mongo knows how to deserialize
        private static void RegisterMapIfNeeded<TClass>()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TClass)))
                BsonClassMap.RegisterClassMap<TClass>();
        }

        public T Create(T document)
        {
            document.DateCreated = DateTime.Now;
            document.LastModified = DateTime.Now;
            
            Collection.InsertOne(document);
            
            return document;
        }

        public void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            Collection.DeleteOne(filter);
        }

        public T Get(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id.ToString()));
            
            return Collection.Find(filter).FirstOrDefault();
        }

        public ICollection<T> GetAll()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public T Update(T document)
        {
            var filter = Builders<T>.Filter.Eq("_id", document.Id);
            return Collection.FindOneAndReplace<T>(filter, document);
        }
    }
}
