using System.Collections.Generic;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ILogMongoDAL : IBaseMongoDAL<Log>
    {
        ICollection<Log> LoadLogs(int animalId);
        ICollection<Log> AddLogs(Log log);
    }
}
