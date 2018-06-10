using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface ILoginBusiness : IBaseBusiness<LoginModel>
    {
        int Login(Login login);
    }
}
