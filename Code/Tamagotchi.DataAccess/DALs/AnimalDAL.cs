using System.Collections.Generic;
using System.Linq;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class AnimalDAL : BaseDAL<Animal>, IAnimalDAL
    {
        public AnimalDAL(TamagotchiContext context) : base(context)
        {
        }
        
        public ICollection<Animal> GetByUser(int id)
        {
            return Set.AsQueryable().Where(x => x.CreatorId == id).ToList();
        }
    }
}
