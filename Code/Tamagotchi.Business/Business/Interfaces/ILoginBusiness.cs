using System;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface ILoginBusiness : IBaseBusiness<LoginModel>
    {
        Guid Login(LoginModel login);
    }
}
