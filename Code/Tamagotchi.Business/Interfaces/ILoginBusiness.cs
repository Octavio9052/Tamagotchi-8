using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface ILoginBusiness : IBaseBusiness<LoginModel, Login>
    {
        int Login(Login login);
    }
}
