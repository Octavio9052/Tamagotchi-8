using AutoMapper;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.REST
{
           public class AutoMapperConfiguration : Profile
           {
                      public void Configure()
                      {
                                 CreateMap<PetModel, Pet>()
                                            .ForMember(x => x.OwnerId,
                                                       m => m.MapFrom(a => a.Owner.Id))

                                            .ForMember(x => x.AnimalId,
                                                       m => m.MapFrom(a => a.Animal.Id));

                                 CreateMap<Pet, PetModel>()
                                            .ForMember(x => x.Owner.Id,
                                                       m => m.MapFrom(a => a.OwnerId))

                                            .ForMember(x => x.Animal.Id,
                                                       m => m.MapFrom(a => a.AnimalId));


                      }   
           }
}