using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface IUserBusiness : IBaseBusiness<UserModel>
    {
        UserModel Create(LoginModel login, string name, string photoUri);
            //name, photo, email, password
    }
}
