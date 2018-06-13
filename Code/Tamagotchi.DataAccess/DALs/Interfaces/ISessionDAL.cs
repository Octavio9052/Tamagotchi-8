using System;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ISessionDAL : IBaseRelationalDAL<Session>
    {
        Session GetByGUID(Guid guid);
    }
}
