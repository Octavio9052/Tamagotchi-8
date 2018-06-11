using System.Collections.Generic;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface IAnimalBusiness : IBaseBusiness<AnimalModel>
    {
        ICollection<AnimalModel> GetByUser(int id);
        AnimalModel Create(Animal animal, byte[] package);
        AnimalModel Update(Animal animal, byte[] package);
    }
}
