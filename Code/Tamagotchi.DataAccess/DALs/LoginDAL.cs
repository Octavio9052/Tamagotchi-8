using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public class LoginDAL : BaseDAL<Login>, ILoginDAL
    {
        public Login Create(Login entity)
        {
            throw new NotImplementedException();
        }

        public Login Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Login Update(Login entity)
        {
            throw new NotImplementedException();
        }

        Login IBaseDAL<Login>.Get(int id)
        {
            throw new NotImplementedException();
        }

        ICollection<Login> IBaseDAL<Login>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
