using System.Collections.Generic;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IPetDAL : IBaseDAL<Pet>
    {
        ICollection<Pet> GetByUser(int userId);
        ICollection<Pet> GetByAnimal(int animalId);
    }
}
