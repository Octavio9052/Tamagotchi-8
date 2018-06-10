using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity
    {
        
        protected readonly DbSet<T> Set;
        
        protected BaseDAL(DbContext context)
        {
            Set = context.Set<T>();
        }

        public virtual T Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastModified = DateTime.Now;
            
            Set.Add(entity);
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = Set.Find(id);
            if (entity != null)
            {
                Set.Remove(entity);
            }
        }

        public virtual T Get(int id)
        {
            return Set.Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return Set.ToList();
        }

        public virtual T Update(T entity)
        {
            var existingEntity = Set.Find(entity.Id);
            
            existingEntity.LastModified = DateTime.Now;
            
//            Set.F(existingEntity).CurrentValues.SetValues(entity);
            
            return existingEntity;
        }
    }
}
