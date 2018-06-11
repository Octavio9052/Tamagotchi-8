using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ICSharpCode.SharpZipLib.Zip;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Business.Services;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class AnimalBusiness : BaseBusiness<AnimalModel, Animal>, IAnimalBusiness
    {
        private static readonly List<string> ImageExtensions = new List<string> {".JPG", ".GIF", ".PNG"};

        private readonly CloudService _cloudService;
        private readonly ILogDAL _logDal;

        public AnimalBusiness(IAnimalDAL baseDal, IMapper mapper, CloudService cloudService, ILogDAL logDal) : base(
            baseDal, mapper)
        {
            _cloudService = cloudService;
            _logDal = logDal;
        }


        public ICollection<AnimalModel> GetByUser(string Id)
        {
            var animals = ((IAnimalDAL) BaseDal).GetByUser(Id);
            return Mapper.Map<ICollection<AnimalModel>>(animals);
        }

        public AnimalModel Create(AnimalModel animal, byte[] zipFile)
        {
            // Fill blanks
            animal.TimesDownloaded = 0;
            animal.IdleUri = "https://i.imgur.com/wHs2rOm.gif";
            animal.IsReady = false;
            animal.IsActive = true;

            var animalModel = base.Create(animal);

            SaveFiles(zipFile, animalModel);
            return animalModel;
        }

        public AnimalModel Update(AnimalModel animalModel, byte[] zipFile)
        {
            animalModel.IsReady = false;

            SaveFiles(zipFile, animalModel);

            return base.Update(animalModel);
        }


        public override void Delete(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");

            animal.IsActive = false;

            base.Update(animal);
        }

        public override AnimalModel Get(string id)
        {
            var animal = base.Get(id);

            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");

            if (!animal.IsActive) throw new BusinessLayerExceptions("Animal is desactivated");

            animal.Logs = LoadLogs(animal.Id);

            return animal;
        }

        //PRIVATE

        private ICollection<LogModel> LoadLogs(string animalId)
        {
            var entity = _logDal.LoadLogs(animalId);
            return Mapper.Map<ICollection<LogModel>>(entity);
        }

        private async Task<string> FindSaveFile(ZipEntry entryFile, ZipFile file, string fileName)
        {
            try
            {
                using (var stream = file.GetInputStream(entryFile))
                {
                    return await _cloudService.ProcessImageFromStream(stream, fileName);
                }
            }
            catch (Exception ex)
            {
                throw new BusinessLayerExceptions(ex);
            }
        }

        private async void SaveFiles(byte[] zipFile, AnimalModel animalModel)
        {
            var fileSuffixes = new[] {"eat", "sleep", "play", "main", "dll"};
            var allowedExtensions = new[] {"jpg", "gif", "png", "dll"};

//            using (var stream = new MemoryStream(zipFile))
//            {
//                await _cloudService.ProcessFileFromStream(stream, animalModel.Id + "_zip.zip");
//                stream.Position = 0;
//
//                using (var zipArchive = new ZipFile(stream))
//                {
//                    Task<string> taskMain;
//
//                    foreach (ZipEntry zipEntry in zipArchive)
//                    {
//                        if (!zipEntry.IsFile)
//                            continue;
//
//                        var entryFileName = Path.GetFileName(zipEntry.Name);
//
//                        var fileExtension = allowedExtensions.First(extension => extension.Equals(Path.GetExtension(entryFileName),StringComparison.InvariantCultureIgnoreCase));
//                        
//                        var fileSuffix = fileSuffixes.First(fileType =>
//                            entryFileName != null &&
//                            entryFileName.IndexOf(fileType, StringComparison.InvariantCultureIgnoreCase) > -1
//                        );
//                        
//                        var fileName = $"{animalModel.Id}_{fileSuffix}.{fileExtension}";
//
//                        taskMain = FindSaveFile(zipEntry, zipArchive, fileName);
//                    }
//
//                    animalModel.PacketUri = taskDll.Result;
//                    animalModel.IdleUri = await taskMain;
//                    animalModel.EatUri = taskEat.Result;
//                    animalModel.SleepUri = taskSleep.Result;
//                    animalModel.PlayUri = taskPlay.Result;
//
//                    animalModel.IsActive = true;
//                    animalModel.IsReady = true;
//                }

                base.Update(animalModel);
            }
        }

}