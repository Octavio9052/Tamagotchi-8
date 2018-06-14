using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs;

namespace Tamagotchi.REST.Controllers
{
    public class AnimalController : BaseController<AnimalModel, IAnimalBusiness>
    {
        public AnimalController(IAnimalBusiness business, ISessionBusiness sessionBusiness) : base(business, sessionBusiness)
        {
        }
    }
}