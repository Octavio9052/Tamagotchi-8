using System;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface ILoginBusiness : IBaseBusiness<LoginModel>
    {
        Guid Login(LoginModel login);
    }
}
