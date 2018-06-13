using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Helpers
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserModel, User>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<AnimalModel, Animal>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<LoginModel, Login>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<SessionModel, Session>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));

            CreateMap<User, UserModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<Animal, AnimalModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<Login, LoginModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));
            CreateMap<Session, SessionModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id.ToString()));

            CreateMap<PetModel, Pet>().ReverseMap();
            CreateMap<LogModel, Log>().ReverseMap();
        }
    }
}
