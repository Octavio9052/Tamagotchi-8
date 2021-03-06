﻿using System.Collections.Generic;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IAnimalDAL : IBaseRelationalDAL<Animal>
    {
        ICollection<Animal> GetByUser(string id);
    }
}
