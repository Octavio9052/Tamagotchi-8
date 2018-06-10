using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class SessionBusiness : BaseBusiness<SessionModel, Session>, ISessionBusiness
    {
        public SessionBusiness(ISessionDAL baseDAL, IMapper mapper) : base(baseDAL, mapper)
        {

        }
    }
}
