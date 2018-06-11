﻿using System;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Interfaces
{
    public interface ISessionBusiness : IBaseBusiness<SessionModel>
    {
        UserModel ValidSession(Guid userToken); 
    }
}
