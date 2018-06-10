using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class PetBusiness : BaseMongoBusiness<PetModel, Pet>, IPetBusiness
    {
        public PetBusiness(IPetMongoDAL baseMongoDAL, IMapper mapper) : base(baseMongoDAL, mapper)
        {

        }
    }
}
