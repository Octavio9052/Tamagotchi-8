using System;
using System.Linq;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class SessionDAL : BaseDAL<Session>, ISessionDAL
    {
        public Session GetByGUID(Guid guid)
        {
            return Set.FirstOrDefault(x => x.Guid == guid);
        }

        public SessionDAL(TamagotchiContext context) : base(context)
        {
        }
    }
}
