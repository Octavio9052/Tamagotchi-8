using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ISessionDAL : IBaseDAL<Session>
    {
        Session GetByGUID(Guid guid);
    }
}
