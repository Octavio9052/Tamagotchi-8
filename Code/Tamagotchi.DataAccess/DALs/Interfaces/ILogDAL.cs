using System.Collections.Generic;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ILogDAL : IBaseDAL<Log>
    {
        ICollection<Log> LoadLogs(string animalId);
        ICollection<Log> AddLogs(Log log);
    }
}
