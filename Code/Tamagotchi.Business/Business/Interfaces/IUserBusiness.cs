using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IUserBusiness : IBaseBusiness<UserModel>
    {
        UserModel Create(LoginModel login, string name, string photoUri);
            //name, photo, email, password
    }
}
