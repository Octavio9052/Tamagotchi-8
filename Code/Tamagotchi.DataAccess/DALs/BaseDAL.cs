using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class BaseDAL<T> : IBaseRelationalDAL<T> where T : BaseRelationalEntity
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> Set;
        
        protected BaseDAL(DbContext context)
        {
            _context = context;
            Set = context.Set<T>();
        }

        public virtual T Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.LastModified = DateTime.Now;
            
            Set.Add(entity);
            return entity;
        }

        public virtual void Delete(string id)
        {
            var entity = Set.Find(id);
            if (entity != null)
            {
                Set.Remove(entity);
            }
        }

        public virtual T Get(Guid id)
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
            
            entity.LastModified = DateTime.Now;
            
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            
            return existingEntity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
