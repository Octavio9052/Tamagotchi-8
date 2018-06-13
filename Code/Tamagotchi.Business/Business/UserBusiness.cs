using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class UserBusiness : BaseBusiness<UserModel, User, IUserDAL>, IUserBusiness
    {
        private readonly ISessionBusiness _sessionBusiness;

        public UserBusiness(IUserDAL baseDAL, IMapper mapper) : base(baseDAL, mapper)
        {
        }

        public UserModel Create(LoginModel login, string name, string photoUri = null)
        {
            return null;
        }
    }
}