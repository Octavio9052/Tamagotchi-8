using System.Collections.Generic;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IBaseMongoDAL<T> where T : BaseDocument
    {
        T Get(string id, string collectionName);
        ICollection<T> GetAll(string collectionName);
        T Create(T document);
        void Delete(string id, string collectionName);
        T Update(T document);
    }
}
