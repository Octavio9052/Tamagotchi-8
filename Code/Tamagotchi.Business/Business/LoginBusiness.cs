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
        private readonly ISessionDAL _sessionDal;

        public LoginBusiness(ILoginDAL baseDal, IMapper mapper,ISessionDAL sessionDal) : base(baseDal, mapper)
        {
            this._sessionDal = sessionDal;
        }

        public Guid Login(LoginModel login)
        {
            var existingLogin = ((ILoginDAL)BaseDal).Login(login.Email, login.Password);

            if (existingLogin == null) return default(Guid);
            
            var newSession = new Session { Guid = Guid.NewGuid(), ExpirationDate = DateTime.Now.AddMinutes(15), UserId = existingLogin.UserId };
            
            newSession = _sessionDal.Create(newSession);
            this._sessionDal.Save();
            
            return newSession.Guid;
        }
    }
}
