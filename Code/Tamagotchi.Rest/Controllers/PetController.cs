using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    public class PetController : BaseController<PetModel, IPetBusiness>
    {
        public PetController(IPetBusiness business, ISessionBusiness sessionBusiness) : base(business, sessionBusiness)
        {
        }
    }
}