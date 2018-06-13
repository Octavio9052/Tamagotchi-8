using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class UserBusiness : BaseBusiness<UserModel, User, IUserDAL>, IUserBusiness
    {
        private readonly ILoginDAL _loginDal;

        public UserBusiness(IUserDAL baseDAL, IMapper mapper,ILoginDAL loginDal) : base(baseDAL, mapper)
        {
            this._loginDal = loginDal;
        }

        public UserModel Create(LoginModel login, string name, string photoUri = null)
        {
            var user =this.BaseDal.Create(new User {Name = name});
            ((IUserDAL) this.BaseDal).Save();
            login.UserId = user.Id.ToString();
            this._loginDal.Create(this.Mapper.Map<Login>(login));
            this._loginDal.Save();
            return this.Mapper.Map<UserModel>(user);
        }
    }
}