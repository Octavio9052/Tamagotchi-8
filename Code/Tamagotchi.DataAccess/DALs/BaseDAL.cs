using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.DataAccess.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity
    {
        private const string CONNECTION_STRING = "mongodb://localhost";
        private const string MONGO_DB = "tamagotchi-009052";
        protected DbContext _dbContext;
        protected IMongoDatabase _dbMongo;

        public BaseDAL()
        {
            this._dbContext = new TamagotchiContext();
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
