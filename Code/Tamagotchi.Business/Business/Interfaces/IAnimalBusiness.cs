using System.Collections.Generic;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface IAnimalBusiness : IBaseBusiness<AnimalModel>
    {
        ICollection<AnimalModel> GetByUser(string id);
    }
}
