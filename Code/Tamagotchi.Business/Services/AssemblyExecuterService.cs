﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Core.GameRules;
using Tamagotchi.Core.PlayStatus;
using Tamagotchi.DataAccess.DataModels;
using Action = Tamagotchi.Common.Enums.Action;

namespace Tamagotchi.Business.Services
{
    public class AssemblyExecuterService
    {
        public const string FunctionFailErrorMessage = "Dll fail at '{0}' fucntion.";
        public const string AssemblyErrorMessage = "Dll failed to load.";
        public const string DomainName = "New Domain";

        private readonly List<string> _errorMessages;
        private AssemblyLoaderService _loader;

        public AssemblyExecuterService(List<string> errorMessages)
        {
            _errorMessages = errorMessages;
        }


        public GameStatus ExecuteAssembly(string url, Action action, Pet pet)
        {
            var dllFile = Load(url);
            if (dllFile == null) throw new BusinessLayerExceptions("Error when trying to load the file");

            var appDomain = CreateAppDomain();

            LoadAssembly(dllFile);

            var methodName = GetMethod(action);
            var response = WorkClass(pet, methodName);

            UnloadAssembly(appDomain);

            return response;
        }

        private string GetMethod(Action action)
        {
            switch (action)
            {
                case Action.Eat:
                    return "Eat";
                case Action.Sleep:
                    return "Sleep";
                case Action.Play:
                    return "Play";
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        private static byte[] Load(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadData(url);
            }

        }

        private AppDomain CreateAppDomain()
        {
            var evidence = new Evidence(AppDomain.CurrentDomain.Evidence);

            var newDomainName = AppDomain.CreateDomain("New Domain", evidence,
                new AppDomainSetup
                {
                    ApplicationName = "Loader",
                    ApplicationBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    DynamicBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                    LoaderOptimization = LoaderOptimization.MultiDomainHost,
                    PrivateBinPath = GetPrivateBin(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
                });

            _loader = (AssemblyLoaderService)newDomainName.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, typeof(AssemblyLoaderService).FullName ?? throw new Exception());
            return newDomainName;
        }

        private string GetPrivateBin(string applicationBase)
        {
            var res = "file:///" + Path.GetFullPath(Path.Combine(applicationBase, @"..\"));
            //var res ="../";
            return res;
        }

        private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            return loadedAssemblies.FirstOrDefault(assembly => assembly.FullName == args.Name);
        }

        private GameStatus WorkClass(Pet pet, string method)
        {
            try
            {
                var objectResult = _loader.ExecuteWithConstructor(typeof(IBaseGameRules), typeof(Pet), method, new object[] { pet }, null);
                var gameResponse = (GameStatus)objectResult;
                return gameResponse;
            }
            catch (Exception ex)
            {
                throw new BusinessLayerExceptions("There was a problem trying to execute the file", ex);
            }
        }

        private Pet LoadData()
        {
            var testPet = new Pet
            {
                Nickname = "Test Data"
            };

            return testPet;
        }

        private bool LoadAssembly(byte[] stream)
        {
            try
            {
                _loader.LoadFromByteArray(stream);
                return true;
            }
            catch (Exception)
            {
                _errorMessages.Add(AssemblyErrorMessage);
                return false;
            }


        }

        private static void UnloadAssembly(AppDomain domain)
        {
            AppDomain.Unload(domain);
        }
    }
}