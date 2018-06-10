using System.Collections.Generic;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IBaseMongoBusiness<T, Y> where T: BaseMnModel where Y : BaseDocument
    {
        T Create(T model);
        ICollection<T> GetAll();
        T Get(string id);
        T Update(T model);
        void Delete(T model);
    }
}
