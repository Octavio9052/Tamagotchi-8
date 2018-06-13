using System;
using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class SessionBusiness : BaseBusiness<SessionModel, Session, ISessionDAL>, ISessionBusiness
    {
        private readonly IUserBusiness _userBusiness;
        public SessionBusiness(ISessionDAL baseDal, IMapper mapper,IUserBusiness userBusiness) : base(baseDal, mapper)
        {
            _userBusiness = userBusiness;
        }

        public UserModel ValidSession(Guid userToken)
        {
            var session = ((ISessionDAL)BaseDal).GetByGUID(userToken);
            
            if (session == null) return null;
            
            session.ExpirationDate = DateTime.Now.AddMinutes(30);
            BaseDal.Update(session);
            BaseDal.Save();
            return _userBusiness.Get(session.UserId.ToString());
        }
    }
}
