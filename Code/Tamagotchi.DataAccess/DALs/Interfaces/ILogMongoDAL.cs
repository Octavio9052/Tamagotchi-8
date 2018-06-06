using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ILogMongoDAL : IBaseMongoDAL<Log>
    {
        ICollection<Log> LoadLogs(int animalId);
        ICollection<Log> AddLogs(Log log);
    }
}
