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

            #region Model To Entity

            CreateMap<UserModel, User>(MemberList.Destination)
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<AnimalModel, Animal>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => Guid.Parse(source.User.Id)))
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<LoginModel, Login>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            CreateMap<SessionModel, Session>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => Guid.Parse(source.Id)));

            #endregion

            #region Entity To Model

            CreateMap<User, UserModel>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Animal, AnimalModel>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()))
                .ForSourceMember(source => source.UserId, opt => opt.Ignore());

            CreateMap<Login, LoginModel>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            CreateMap<Session, SessionModel>(MemberList.Source)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id.ToString()));

            #endregion

            
        }
    }
}