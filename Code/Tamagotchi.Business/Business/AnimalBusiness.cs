using System;
using System.Collections.Generic;
using System.IO;
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
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".GIF", ".PNG" };
        
        private readonly CloudService _cloudService;
        private readonly ILogDAL _logDal;

        public AnimalBusiness(IAnimalDAL baseDal, IMapper mapper, CloudService cloudService, ILogDAL logDal) : base(baseDal, mapper)
        {
            _cloudService = cloudService;
            _logDal = logDal;
        }


        public ICollection<AnimalModel> GetByUser(int Id)
        {
            var animals = ((IAnimalDAL)BaseDal).GetByUser(Id);
            return Mapper.Map<ICollection<AnimalModel>>(animals);
        }

        public AnimalModel Create(AnimalModel animal, byte[] zipFile)
        {
            // Validate input from desktop
            foreach (var entry in animal.MaxGamePoints)
            {
                if (entry.Value <= 0 && !entry.Key.Contains("Max")) throw new BusinessLayerExceptions("Not valid: " + entry.Key);
            }
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