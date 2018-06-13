using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class PetBusiness : BaseBusiness<PetModel, Pet, IPetDAL>, IPetBusiness
    {
        public PetBusiness(IPetDAL baseDal, IMapper mapper) : base(baseDal, mapper)
        {

        }
    }
}
