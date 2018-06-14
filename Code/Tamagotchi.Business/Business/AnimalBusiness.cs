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
using System.Linq;

namespace Tamagotchi.Business.Business
{
    public class AnimalBusiness : BaseBusiness<AnimalModel, Animal, IAnimalDAL>, IAnimalBusiness
    {
        // private readonly StorageService _storageService;
        private readonly ILogDAL _logDal;
        private readonly IUserDAL userDAL;
        public AnimalBusiness(
            IAnimalDAL baseDal,
            ILogDAL logDal,
            IMapper mapper,
            IUserDAL userDal
            // StorageService storageService
        ) : base(baseDal, mapper)
        {
            // _storageService = storageService;
            _logDal = logDal;
            userDAL = userDal;
        }

        public override ICollection<AnimalModel> GetAll()
        {
            var models =  base.GetAll().ToList();
            var results = models.Select(model =>
            {
                var user = userDAL.Get(Guid.Parse(model.User.Id));
                model.User = Mapper.Map<UserModel>(user);
                return model;
            });

            return results.ToArray();
        }


        public ICollection<AnimalModel> GetByUser(string id)
        {
            var animals = BaseDal.GetByUser(id);
            return Mapper.Map<ICollection<AnimalModel>>(animals);
        }

        public override async Task<AnimalModel> Create(AnimalModel animal)
        {
            animal.IsActive = true;

            var entity = Mapper.Map<Animal>(animal);
            entity = BaseDal.Create(entity);
            BaseDal.Save();

            entity.PacketUri = await SaveFile(animal.PacketUri, $"{entity.Id}_packet", animal.PacketFile);
            entity.IsReady = true;

            entity = BaseDal.Update(entity);
            BaseDal.Save();
            
            return Mapper.Map<AnimalModel>(entity);
        }

        public override async Task<AnimalModel> Update(AnimalModel animal)
        
        {
            animal.PacketUri = await SaveFile(animal.PacketUri, $"{animal.Id}_packet", animal.PacketFile);
            animal.IsReady = true;

            var entity = BaseDal.Update(Mapper.Map<Animal>(animal));
            BaseDal.Save();

            return Mapper.Map<AnimalModel>(entity);
        }

        public override async void Delete(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("AnimalImpl Doesn't Exists");

            animal.IsActive = false;

            await base.Update(animal);
        }

        public override AnimalModel Get(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("AnimalImpl Doesn't Exists");

            if (!animal.IsActive) throw new BusinessLayerExceptions("AnimalImpl is desactivated");

            animal.Logs = LoadLogs(animal.Id);

            return animal;
        }

        private async Task<string> SaveFile(string originalFileName, string newFileName, string base64Content)
        {
            var extension = Path.GetExtension(originalFileName);

            var fileName = $"{newFileName}.{extension}";
            var data = System.Convert.FromBase64String(base64Content);
            var ms = new MemoryStream(data);
            // await _storageService.ProcessFileFromStream(ms, fileName);

            return fileName;
        }

        private IEnumerable<LogModel> LoadLogs(string animalId)
        {
            var entity = _logDal.LoadLogs(animalId);

            return Mapper.Map<ICollection<LogModel>>(entity);
        }
    }
}