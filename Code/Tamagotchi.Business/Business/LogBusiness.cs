using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class LogBusiness : BaseBusiness<LogModel, Log>, ILogBusiness
    {
        public LogBusiness(ILogDAL baseDal, IMapper mapper) : base(baseDal, mapper)
        {
        }
    }
}
