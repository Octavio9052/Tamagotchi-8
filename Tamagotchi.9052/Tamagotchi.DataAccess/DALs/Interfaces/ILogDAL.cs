using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ILogDAL : IBaseDAL<Log>
    {
        ICollection<Log> LoadLogs(int animalId, int petId);
        ICollection<Log> AddLogs(Log log);
    }
}
