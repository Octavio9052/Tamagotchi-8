using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IPetMongoDAL : IBaseMongoDAL<Pet>
    {
        ICollection<Pet> GetByUser(int userId);
        ICollection<Pet> GetByAnimal(int animalId);
    }
}
