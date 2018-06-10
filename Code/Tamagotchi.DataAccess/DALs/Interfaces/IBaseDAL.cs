using System.Collections.Generic;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IBaseDAL<T> where T : IBaseEntity
    {
        T Get(string id);
        ICollection<T> GetAll();
        T Create(T entity);
        void Delete(string id);
        T Update(T entity);
    }
}
