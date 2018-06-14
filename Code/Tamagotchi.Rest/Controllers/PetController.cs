using System.Web.Http.Cors;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PetController : BaseController<PetModel, IPetBusiness>
    {
        public PetController(IPetBusiness business, ISessionBusiness sessionBusiness) : base(business, sessionBusiness)
        {
        }
    }
}