using System.Collections.Generic;
using System.Linq;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class AnimalDAL : BaseDAL<Animal>, IAnimalDAL
    {
        public AnimalDAL(TamagotchiContext context) : base(context)
        {
        }
        
        public ICollection<Animal> GetByUser(string id)
        {
            return Set.AsQueryable().Where(x => x.UserId.ToString() == id).ToList();
        }
    }
}
