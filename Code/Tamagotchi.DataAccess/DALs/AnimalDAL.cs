using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class AnimalDAL : BaseDAL<Animal>, IAnimalDAL
    {
        public ICollection<Animal> GetByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
