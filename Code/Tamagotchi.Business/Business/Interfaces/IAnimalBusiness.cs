using System.Collections.Generic;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IAnimalBusiness : IBaseBusiness<AnimalModel>
    {
        ICollection<AnimalModel> GetByUser(string id);
    }
}
