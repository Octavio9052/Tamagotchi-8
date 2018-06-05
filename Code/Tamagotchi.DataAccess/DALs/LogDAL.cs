using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

using Tamagotchi.Common.Entities;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class LogDAL : BaseDAL<Log>, ILogDAL
    {
        public ICollection<Log> AddLogs(Log log)
        {
            throw new NotImplementedException();
        }

        public ICollection<Log> LoadLogs(int animalId, int petId)
        {
            throw new NotImplementedException();
        }
    }
}
