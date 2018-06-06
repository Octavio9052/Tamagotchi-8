using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class LogBusiness : BaseMongoBusiness<LogModel, Log>, ILogBusiness
    {
        public LogBusiness(ILogMongoDAL baseMongoDAL) : base(baseMongoDAL)
        {

        }
    }
}
