using System.Collections.Generic;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface IBaseBusiness<T> where T : BaseModel
    {   
        T Create(T model);
        ICollection<T> GetAll();
        T Get(string id);
        T Update(T model);
        void Delete(string id);
    }
}
