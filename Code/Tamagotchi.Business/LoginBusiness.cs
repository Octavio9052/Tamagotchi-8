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
    public class LoginBusiness : BaseBusiness<LoginModel, Login>, ILoginBusiness
    {
        public LoginBusiness(ILoginDAL baseDAL, IMapper mapper) : base(baseDAL, mapper)
        {
        }

        public int Login(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
