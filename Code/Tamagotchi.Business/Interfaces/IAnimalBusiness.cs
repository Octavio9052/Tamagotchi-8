using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Common.Entities;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IAnimalBusiness : IBaseBusiness<AnimalModel, Animal>
    {
        ICollection<AnimalModel> GetByUser(int id);
        AnimalModel Create(Animal animal, byte[] package);
        AnimalModel Update(Animal animal, byte[] package);
    }
}
