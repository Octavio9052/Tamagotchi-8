using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class AnimalDAL : BaseDAL<Animal>, IAnimalDAL
    {
        public ICollection<Animal> GetByUser(int id)
        {
            return this._dbContext.Set<Animal>().AsQueryable().Where(x => x.CreatorId == id).ToList();
        }
    }
}
