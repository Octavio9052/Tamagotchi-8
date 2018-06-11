using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class UserBusiness : BaseBusiness<UserModel, User>, IUserBusiness
    {
        private readonly ISessionBusiness _sessionBusiness;

        public UserBusiness(IUserDAL baseDAL, IMapper mapper, ISessionBusiness sessionBusiness) : base(baseDAL, mapper)
        {
            _sessionBusiness = sessionBusiness;
        }

        public UserModel Create(LoginModel login, string name, string photoUri = null)
        {
            return null;
        }
    }
}
