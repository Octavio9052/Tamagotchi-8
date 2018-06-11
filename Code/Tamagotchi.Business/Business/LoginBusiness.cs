using AutoMapper;
using System;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Business
{
    public class LoginBusiness : BaseBusiness<LoginModel, Login>, ILoginBusiness
    {
        private readonly ISessionBusiness _sessionBusiness;

        public LoginBusiness(ILoginDAL baseDAL, IMapper mapper,ISessionBusiness sessionBusiness) : base(baseDAL, mapper)
        {
        }

        public Guid Login(LoginModel login)
        {
            var existingLogin = ((ILoginDAL)BaseDal).Login(login.Email, login.Password);

            if(existingLogin != null)
            {
                var newSession = new SessionModel { Guid = Guid.NewGuid(), ExpirationDate = DateTime.Now.AddMinutes(15), UserId = existingLogin.UserId };
                newSession = _sessionBusiness.Create(newSession);
                return newSession.Guid;
            }

            return default(Guid);
        }
    }
}
