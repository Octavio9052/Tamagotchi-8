using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class LogBusiness : BaseMongoBusiness<LogModel, Log>, ILogBusiness
    {
        public LogBusiness(ILogMongoDAL baseMongoDAL, IMapper mapper) : base(baseMongoDAL, mapper)
        {

        }
    }
}
