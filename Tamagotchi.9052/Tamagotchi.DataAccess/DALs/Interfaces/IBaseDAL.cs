using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IBaseDAL<T> where T : BaseEntity
    {
        T Get(int id);
        ICollection<T> GetAll();
        T Create(T entity);
        void Delete(int id);
        T Update(T entity);
    }
}
