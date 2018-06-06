using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public class LoginDAL : BaseDAL<Login>, ILoginDAL
    {
        public Login Login(string username, string password)
        {
            var login = this._dbContext.Set<Login>().FirstOrDefault(x => (x.Email == username) && (x.Password == password));

            if (login != null)
            {
                return login;
            }

            return null;
        }
    }
}
