using System;
using AutoMapper;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PetModel, Pet>().ReverseMap();

            CreateMap<LogModel, Log>().ReverseMap();

            CreateMap<UserModel, User>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<AnimalModel, Animal>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => Guid.Parse(source.User.Id)));

            CreateMap<LoginModel, Login>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<SessionModel, Session>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Animal, AnimalModel>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Login, LoginModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Session, SessionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));
            
        }
    }
}