using System.Collections.Generic;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IBaseBusiness<T, Y> where T : BaseModel where Y : BaseEntity
    {   
        T Create(T model);
        ICollection<T> GetAll();
        T Get(T model);
        T Update(T model);
        void Delete(T model);
    }
}
