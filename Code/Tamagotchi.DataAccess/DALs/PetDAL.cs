using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class PetDAL : BaseDAL<Pet>, IPetDAL
    {
        public ICollection<Pet> GetByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
