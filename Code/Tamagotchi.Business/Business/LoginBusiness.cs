using System;
using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

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
