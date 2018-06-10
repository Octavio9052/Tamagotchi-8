using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ICSharpCode.SharpZipLib.Zip;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Business.Services;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class AnimalBusiness : BaseBusiness<AnimalModel, Animal>, IAnimalBusiness
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".GIF", ".PNG" };
        private CloudService _cloudService;
        private ILogMongoDAL _logMongoDAL;


        public AnimalBusiness(IAnimalDAL baseDal, IMapper mapper, CloudService cloudService, ILogMongoDAL logMongoDAL) : base(baseDal, mapper)
        {
            _cloudService = cloudService;
            _logMongoDAL = logMongoDAL;
        }


        public ICollection<AnimalModel> GetByUser(int Id)
        {
            var animals = ((IAnimalDAL)_baseDAL).GetByUser(Id);
            return _mapper.Map<ICollection<AnimalModel>>(animals);
        }

        public AnimalModel Create(AnimalModel animal, byte[] zipFile)
        {
            // Validate input from desktop
            if (String.IsNullOrEmpty(animal.Name)) throw new BusinessLayerExceptions("Empty or not valid: Name");
            if (String.IsNullOrEmpty(animal.Description)) throw new BusinessLayerExceptions("Empty or not valid: Description");
            foreach (var entry in animal.MaxGamePoints)
            {
                if (entry.Value <= 0 && !entry.Key.Contains("Max")) throw new BusinessLayerExceptions("Not valid: " + entry.Key);
            }
            if (animal.Creator.Id == 0 || animal.Creator.Id < 0) throw new BusinessLayerExceptions("Empty or not valid: HealthPoints");
            if (zipFile == null) throw new BusinessLayerExceptions("Empty or not valid: File");

            // Fill blanks
            animal.TimesDownloaded = 0;
            animal.IdleUri = "https://i.imgur.com/wHs2rOm.gif";
            animal.IsReady = false;
            animal.IsActive = true;


            var animalModel = base.Create(animal);
         
            var backgroundWorkerThread = new Thread(() => SaveFiles(zipFile, animalModel));
            backgroundWorkerThread.IsBackground = true;
            backgroundWorkerThread.Start();

            return animalModel;
        }

        public AnimalModel Update(AnimalModel animalModel, byte[] zipFile)
        {
            if (String.IsNullOrEmpty(animalModel.Name)) throw new BusinessLayerExceptions("Empty or not valid: Name");
            if (String.IsNullOrEmpty(animalModel.Description)) throw new BusinessLayerExceptions("Empty or not valid: Description");
            foreach (var entry in animalModel.MaxGamePoints)
            {
                if (entry.Value <= 0 && !entry.Key.Contains("Max")) throw new BusinessLayerExceptions("Not valid: " + entry.Key);
            }

            animalModel.IsReady = false;

            var backgroundWorkerThread = new Thread(() => SaveFiles(zipFile, animalModel));
            backgroundWorkerThread.IsBackground = true;
            backgroundWorkerThread.Start();

            return base.Update(animalModel);
        }


        public override void Delete(AnimalModel animalModel)
        {
            if (animalModel.Id == 0 || animalModel.Id < 0) throw new BusinessLayerExceptions("Empty or not valid: Id");
            var animal = base.Get(animalModel);
            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");
            animal.IsActive = false;
            base.Update(animal);
        }

        public override AnimalModel Get(AnimalModel animalModel)
        {
            if (animalModel.Id == 0 || animalModel.Id < 0) throw new BusinessLayerExceptions("Empty or not valid: Id");
            var animal = base.Get(animalModel);
            if (animal == null) throw new BusinessLayerExceptions("Animal Doesn't Exists");
            if (!animal.IsActive) throw new BusinessLayerExceptions("Animal is desactivated");
            animal.Logs = LoadLogs(animal.Id);
            return animal;
        }

        //PRIVATE

        private ICollection<LogModel> LoadLogs(int animalId)
        {
            var entity = _logMongoDAL.LoadLogs(animalId);
            return _mapper.Map<ICollection<LogModel>>(entity);
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

        private void SaveFiles(byte[] zipFile, AnimalModel animalModel)
        {
            try
            {
                using (var stream = new MemoryStream(zipFile))
                {
                    var task = _cloudService.ProcessFileFromStream(stream, animalModel.Id + "_zip.zip");
                    animalModel.PacketUri = task.Result;
                    stream.Position = 0;
                    using (var zipArchive = new ZipFile(stream))
                    {


                        Task<string> taskMain = null, taskDll = null, taskEat = null, taskSleep = null, taskPlay = null;
                        foreach (ZipEntry zipEntry in zipArchive)
                        {
                            if (!zipEntry.IsFile)
                                continue;

                            var entryFileName = zipEntry.Name; // or Path.GetFileName(zipEntry.Name) to omit folder



                            if (entryFileName.ToLower().Contains("eat") &&
                                ImageExtensions.Contains(Path.GetExtension(entryFileName)
                                    ?.ToUpperInvariant()))
                            {
                                taskEat = FindSaveFile(zipEntry, zipArchive,
                                    animalModel.Id + "_eat" + Path.GetExtension(entryFileName));
                                continue;
                            }
                            if (entryFileName.ToLower().Contains("sleep") &&
                                ImageExtensions.Contains(Path.GetExtension(entryFileName)
                                    ?.ToUpperInvariant()))
                            {
                                taskSleep = FindSaveFile(zipEntry, zipArchive,
                                    animalModel.Id + "_sleep" + Path.GetExtension(entryFileName));
                                continue;
                            }
                            if (entryFileName.ToLower().Contains("play") &&
                                ImageExtensions.Contains(Path.GetExtension(entryFileName)
                                    ?.ToUpperInvariant()))
                            {
                                taskPlay = FindSaveFile(zipEntry, zipArchive,
                                    animalModel.Id + "_play" + Path.GetExtension(entryFileName));
                                continue;
                            }
                            if (entryFileName.ToLower().Contains("main") &&
                                ImageExtensions.Contains(Path.GetExtension(entryFileName)
                                    ?.ToUpperInvariant()))
                            {
                                taskMain = FindSaveFile(zipEntry, zipArchive,
                                    animalModel.Id + "_main" + Path.GetExtension(entryFileName));
                                continue;
                            }
                            if (entryFileName.ToLower().Contains("dll") && entryFileName.ToLower().EndsWith(".dll"))
                            {
                                taskDll = FindSaveFile(zipEntry, zipArchive,
                                    animalModel.Id + "_dll" + Path.GetExtension(entryFileName));
                            }

                        }


                        animalModel.PacketUri = taskDll.Result;
                        animalModel.IdleUri = taskMain.Result;
                        animalModel.EatUri = taskEat.Result;
                        animalModel.SleepUri = taskSleep.Result;
                        animalModel.PlayUri = taskPlay.Result;
                        animalModel.IsActive = true;
                        animalModel.IsReady = true;
                    }
                    base.Update(animalModel);
                }
            }
            catch (Exception)
            {

            }

        }


        public AnimalModel Create(Animal animal, byte[] package)
        {
            throw new NotImplementedException();
        }

        public AnimalModel Update(Animal animal, byte[] package)
        {
            throw new NotImplementedException();
        }

    }
}