using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IPetDAL : IBaseDAL<Pet>
    {
        ICollection<Pet> GetByUser(int id);
    }
}
