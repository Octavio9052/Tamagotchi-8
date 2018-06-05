using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class PetBusiness : BaseBusiness<PetModel, Pet>, IPetBusiness
    {
        public PetBusiness(IPetDAL baseDAL) : base(baseDAL)
        {

        }
    }
}
