using System;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface ISessionBusiness : IBaseBusiness<SessionModel>
    {
        UserModel ValidSession(Guid userToken); 
    }
}
