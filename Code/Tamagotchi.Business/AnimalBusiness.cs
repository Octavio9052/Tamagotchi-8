using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.Common.Entities;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business
{
    public class AnimalBusiness : BaseBusiness<AnimalModel, Animal>, IAnimalBusiness
    {
        public AnimalBusiness(IAnimalDAL baseDAL) : base(baseDAL)
        {

        }

        public AnimalModel Create(Animal animal, byte[] package)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnimalModel> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public AnimalModel Update(Animal animal, byte[] package)
        {
            throw new NotImplementedException();
        }
    }
}
