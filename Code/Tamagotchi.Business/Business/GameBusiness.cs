using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.SDK;

namespace Tamagotchi.Business.Business
{
    public class GameBusiness : IGameBusiness
    {
        private readonly IPetDAL _petDal;
        private readonly IAnimalDAL _animalDal;
        private readonly ILogDAL _logDal;

        public GameBusiness(IPetDAL petDal, ILogDAL logDal, IAnimalDAL animalDal)
        {
            _petDal = petDal;
            _logDal = logDal;
            _animalDal = animalDal;
        }

        public GameResult Play(GameMove move)
        {
            var result = new GameResult();

            var pet = _petDal.Get(Guid.Parse(move.PetId));
            var animal = _animalDal.Get(Guid.Parse(pet.AnimalId));

            using (var client = new WebClient())
            {
                var data = client.DownloadData(animal.PacketUri);
                var newDomain = AppDomain.CreateDomain("dllDomain");
                var assembly = Assembly.Load(data);

                var animalType = assembly.GetExportedTypes()
                    .FirstOrDefault(type =>
                        type.GetCustomAttribute<AnimalAttribute>() != null &&
                        type.IsSubclassOf(typeof(AnimalImpl))
                    );

                if (animalType == null)
                    return null;

                var instance =
                    newDomain.CreateInstanceAndUnwrap(assembly.ToString(), animalType.ToString()) as AnimalImpl;

                if (instance == null)
                    return null;

                var petStatus = new 
                {
    
                };

            }

            return result;
        }
    }
}