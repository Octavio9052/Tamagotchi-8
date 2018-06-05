using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Common.Entities;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Business.Interfaces
{
    public interface IUserBusiness : IBaseBusiness<UserModel, User>
    {
        UserModel Create(LoginModel login, string name, string photoUri);
            //name, photo, email, password
    }
}
