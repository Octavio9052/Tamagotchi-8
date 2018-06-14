using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using AutoMapper;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.SDK;
using Action = Tamagotchi.Common.Enums.Action;

namespace Tamagotchi.Business.Business
{
    public class GameBusiness : IGameBusiness
    {
        private readonly IPetDAL _petDal;
        private readonly IAnimalDAL _animalDal;
        private readonly ILogDAL _logDal;
        private readonly IUserDAL _userDal;
        private readonly IMapper _mapper;

        public GameBusiness(IPetDAL petDal, ILogDAL logDal, IAnimalDAL animalDal, IMapper mapper, IUserDAL userDal)
        {
            _petDal = petDal;
            _logDal = logDal;
            _animalDal = animalDal;
            _mapper = mapper;
            _userDal = userDal;
        }

        public GameResult Play(GameMove move)
        {
            var result = new GameResult();

            var pet = _petDal.Get(Guid.Parse(move.PetId));
            var animal = _animalDal.Get(Guid.Parse(pet.AnimalId));
            var user = _userDal.Get(Guid.Parse(pet.OwnerId));

            var petStatus = new PetStatus
            {
                PlayPoints = pet.PlayPoints,
                EatPoints = pet.EatPoints,
                SleepPoints = pet.SleepPoints
            };

            var log = new LogModel
            {
                PetId = pet.Id.ToString(),
                PetName = pet.Nickname,
                AnimalId = animal.Id.ToString(),
                AnimalName = animal.Name,
                UserId = pet.OwnerId,
                Username = user.Name,
                LastModified = DateTime.Now,
                DateCreated = DateTime.Now,
                Message = $"{pet.Nickname} has {move.Action.ToString()}"
            };

            byte[] data;

            using (var client = new WebClient())
            {
                data = client.DownloadData(animal.PacketUri);
            }

            var newDomain = AppDomain.CreateDomain("dllDomain");
            var assembly = Assembly.Load(data);

            var animalType = assembly.GetExportedTypes()
                .FirstOrDefault(type =>
                    type.GetCustomAttribute<AnimalAttribute>() != null &&
                    type.IsSubclassOf(typeof(AnimalImpl))
                );

            if (animalType == null)
                return null;

            if (!(newDomain.CreateInstanceAndUnwrap(assembly.ToString(), animalType.ToString(), true,
                BindingFlags.Default, null, new object[] {petStatus}, null, new object[] { }) is AnimalImpl instance))
                return null;

            PetStatus finalPetStatus;

            switch (move.Action)
            {
                case Action.Eat:
                    finalPetStatus = instance.Eat();
                    break;
                case Action.Sleep:
                    finalPetStatus = instance.Sleep();
                    break;
                case Action.Play:
                    finalPetStatus = instance.Play();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            pet.EatPoints = finalPetStatus.EatPoints;
            pet.SleepPoints = finalPetStatus.SleepPoints;
            pet.PlayPoints = finalPetStatus.PlayPoints;

            _petDal.Update(pet);
            _logDal.Create(_mapper.Map<Log>(log));

            result.Pet = _mapper.Map<PetModel>(pet);
            result.Log = log;

            return result;
        }
    }
}