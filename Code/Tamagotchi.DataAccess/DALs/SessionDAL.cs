using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class SessionDAL : BaseDAL<Session>, ISessionDAL
    {
        public Session GetByGUID(Guid guid)
        {
            return this._dbContext.Set<Session>().FirstOrDefault(x => x.Guid == guid);
        }
    }
}
