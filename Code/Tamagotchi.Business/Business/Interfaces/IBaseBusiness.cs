using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Business.Interfaces
{
    public interface IBaseBusiness<T> where T : BaseModel
    {   
        Task<T> Create(T model);
        ICollection<T> GetAll();
        T Get(string id);
        Task<T> Update(T model);
        void Delete(string id);
    }
}
