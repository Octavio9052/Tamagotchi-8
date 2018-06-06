using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using AutoMapper;

namespace Tamagotchi.Business
{
    public class PetBusiness : BaseMongoBusiness<PetModel, Pet>, IPetBusiness
    {
        public PetBusiness(IPetMongoDAL baseMongoDAL, IMapper mapper) : base(baseMongoDAL, mapper)
        {

        }
    }
}
