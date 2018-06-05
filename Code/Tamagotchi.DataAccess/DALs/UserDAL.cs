using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        public UserDAL() : base()
        {

        }

        public override User Create(User entity)
        {
            var entityUser = base.Create(entity);

            this._dbContext.Set<User>().Add(entityUser);
            this._dbContext.SaveChanges();
            return entityUser;
        }
    }
}
