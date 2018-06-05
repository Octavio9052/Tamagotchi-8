using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Common.Entities;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IBaseBusiness<T, Y> where T : BaseModel where Y : BaseEntity
    {   
        T Create(T entity);
        ICollection<T> GetAll();
        T Get(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
