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
    public class UserBusiness : BaseBusiness<UserModel, User>, IUserBusiness
    {
        private readonly ISessionBusiness _sessionBusiness;

        public UserBusiness(IUserDAL baseDAL, IMapper mapper, ISessionBusiness sessionBusiness) : base(baseDAL, mapper)
        {
            this._sessionBusiness = sessionBusiness;
        }

        public UserModel Create(LoginModel login, string name, string photoUri)
        {
            return null;
        }
    }
}
