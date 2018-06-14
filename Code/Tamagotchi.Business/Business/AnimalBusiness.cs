using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Tamagotchi.Business.Helpers;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Business.Services.interfaces;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;
using System;

namespace Tamagotchi.Business.Business
{
    public class AnimalBusiness : BaseBusiness<AnimalModel, Animal, IAnimalDAL>, IAnimalBusiness
    {
        private readonly StorageService _storageService;
        private readonly ILogDAL _logDal;

        public AnimalBusiness(
            IAnimalDAL baseDal,
            ILogDAL logDal,
            IMapper mapper,
            StorageService storageService
        ) : base(baseDal, mapper)
        {
            _storageService = storageService;
            _logDal = logDal;
        }


        public ICollection<AnimalModel> GetByUser(string id)
        {
            var animals = BaseDal.GetByUser(id);
            return Mapper.Map<ICollection<AnimalModel>>(animals);
        }

        public override async Task<AnimalModel> Create(AnimalModel animal)
        {
            animal.IsActive = true;


            animal = await base.Create(animal);
            //var entity = new Animal
            //{
            //    DateCreated = DateTime.Now,
            //    LastModified = DateTime.Now,
            //    Description = animal.Description,
            //    Name = animal.Name,
            //    TimesDownloaded = 0,
            //    UserId = Guid.Parse(animal.User.Id),
            //    User = new User
            //    {
                    
            //    }
                
            //};

            //            _storageService.ProcessFileFromStream();

            await Task.WhenAll(
                SaveFile(animal.PacketUri, $"{animal.Id}_packet", animal.PacketFile)
                    .ContinueWith(async packetTask => animal.PacketUri = await packetTask),
                SaveFile(animal.IdleUri, $"{animal.Id}_idle", animal.IdleImage)
                    .ContinueWith(async idleTask => animal.IdleUri = await idleTask),
                SaveFile(animal.PlayUri, $"{animal.Id}_play", animal.PlayImage)
                    .ContinueWith(async playTask => animal.PlayUri = await playTask),
                SaveFile(animal.EatUri, $"{animal.Id}_eat", animal.EatImage)
                    .ContinueWith(async eatTask => animal.EatUri = await eatTask),
                SaveFile(animal.SleepUri, $"{animal.Id}_sleep", animal.SleepImage)
                    .ContinueWith(async sleepTask => animal.SleepUri = await sleepTask)
            );

            animal.IsReady = true;

            var animalModel = await base.Update(animal);

            BaseDal.Save();

            return animalModel;
        }

        public override async Task<AnimalModel> Update(AnimalModel animal)
        {
            animal.IsReady = false;

            await Task.WhenAll(
                SaveFile(animal.PacketUri, $"{animal.Id}_packet", animal.PacketFile)
                    .ContinueWith(async task => animal.PacketUri = await task),
                SaveFile(animal.IdleUri, $"{animal.Id}_idle", animal.IdleImage)
                    .ContinueWith(async task => animal.IdleUri = await task),
                SaveFile(animal.PlayUri, $"{animal.Id}_play", animal.PlayImage)
                    .ContinueWith(async task => animal.PlayUri = await task),
                SaveFile(animal.EatUri, $"{animal.Id}_eat", animal.EatImage)
                    .ContinueWith(async task => animal.EatUri = await task),
                SaveFile(animal.SleepUri, $"{animal.Id}_sleep", animal.SleepImage)
                    .ContinueWith(async task => animal.SleepUri = await task)
            );

            animal.IsReady = true;

            var animalModel = await base.Update(animal);

            BaseDal.Save();

            return animalModel;
        }

        public override async void Delete(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");

            animal.IsActive = false;

            await base.Update(animal);
        }

        public override AnimalModel Get(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");

            if (!animal.IsActive) throw new BusinessLayerExceptions("Animal is desactivated");

            animal.Logs = LoadLogs(animal.Id);

            return animal;
        }

        private async Task<string> SaveFile(string originalFileName, string newFileName, string base64Content)
        {
            var extension = Path.GetExtension(originalFileName);

            var fileName = $"{newFileName}.{extension}";
            byte[] data = System.Convert.FromBase64String(base64Content);
            MemoryStream ms = new MemoryStream(data);
            await _storageService.ProcessFileFromStream(ms, fileName);

            return fileName;
        }

        private IEnumerable<LogModel> LoadLogs(string animalId)
        {
            var entity = _logDal.LoadLogs(animalId);

            return Mapper.Map<ICollection<LogModel>>(entity);
        }
    }
}