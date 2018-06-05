using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.DataAccess.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity
    {
        protected DbContext _dbContext;
        protected MongoClient _mongoClient;
        protected IMongoDatabase _database; 

        public BaseDAL()
        {
            this._dbContext = new TamagotchiContext();
            this._mongoClient = new MongoClient("mongodb://180b1f3b-0ee0-4-231-b9ee:xO5kRtGvglx0pvDIC5v9k7wtv9tp0ZBzLjp0K1aWjO9M67IO6a3yxZsL3SqleqFvunHOcvTqW9EgPwp9BrpAaA==@180b1f3b-0ee0-4-231-b9ee.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
            this._database = this._mongoClient.GetDatabase("tamagotchi-009052");
        }


        public virtual T Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastModified = DateTime.Now;
            this._dbContext.Set<T>().Add(entity);
            this._dbContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(int id)
        {
            T entity = this._dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
            this._dbContext.Set<T>().Remove(entity);
            this._dbContext.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return this._dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual ICollection<T> GetAll()
        {
            return this._dbContext.Set<T>().ToList();
        }

        public virtual T Update(T entity)
        {
            T existingEntity = this._dbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            existingEntity.LastModified = DateTime.Now;
            this._dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            this._dbContext.SaveChanges();
            return existingEntity;
        }
    }
}
