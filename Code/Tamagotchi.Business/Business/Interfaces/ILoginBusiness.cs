using System;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface ILoginBusiness : IBaseBusiness<LoginModel>
    {
        Guid Login(LoginModel login);
    }
}
