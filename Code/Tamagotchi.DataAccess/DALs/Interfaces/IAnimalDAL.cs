using System.Collections.Generic;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IAnimalDAL : IBaseDAL<Animal>
    {
        ICollection<Animal> GetByUser(int id);
    }
}
