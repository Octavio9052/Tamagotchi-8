using System;
using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class LoginBusiness : BaseBusiness<LoginModel, Login, ILoginDAL>, ILoginBusiness
    {
        private readonly ISessionBusiness _sessionBusiness;

        public LoginBusiness(ILoginDAL baseDal, IMapper mapper,ISessionBusiness sessionBusiness) : base(baseDal, mapper)
        {
        }

        public Guid Login(LoginModel login)
        {
            var existingLogin = ((ILoginDAL)BaseDal).Login(login.Email, login.Password);

            if (existingLogin == null) return default(Guid);
            
            var newSession = new SessionModel { Guid = Guid.NewGuid(), ExpirationDate = DateTime.Now.AddMinutes(15), UserId = existingLogin.UserId.ToString() };
            
            newSession = _sessionBusiness.Create(newSession);
            
            return newSession.Guid;
        }
    }
}
