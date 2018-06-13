 using System;
using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Net;
 using System.Reflection;
 using System.Security.Policy;
 using System.Text;
using System.Threading.Tasks;
 using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.Business.Helpers
{
    public class AssemblyService
    {
        public const string FunctionFailErrorMessage = "Dll fail at '{0}' fucntion.";
        public const string AssemblyErrorMessage = "Dll failed to load.";
        public const string DomainName = "New Domain";



        private List<string> _errorMessages;
        private AssemblyLoader _loader;

        public AssemblyService()
        {

        }


        public void ExecuteAssembly(string url, Action action, Pet pet)
        {
            var dllFile = Load(url);
            if (dllFile == null) throw new Exception("Error when trying to load the file");
            var appDomain = CreateAppDomain();
            LoadAssembly(dllFile);
            string methodName = GetMethod(action);
//            var response = WorkClass(pet, methodName);
            UnloadAssembly(appDomain);
//            return null;
        }

        private string GetMethod(Action action)
        {
            return null;
//            var methods = typeof(IGame).GetMethods();
//            if (action == Action.Init)
//            {
//                return "Init";
//            }
//            else if (action == Action.Eat)
//            {
//                return "Eat";
//            }
//            else if (action == Action.Sleep)
//            {
//                return "Sleep";
//            }
//            else if (action == Action.Play)
//            {
//                return "Play";
//            }
//            else
//            {
//                return null;
//            }
        }

        private byte[] Load(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadData(url);
            }

        }

        private AppDomain CreateAppDomain()
        {
            Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);

            AppDomain newDomainName = AppDomain.CreateDomain("New Domain", evidence,
                new AppDomainSetup()
                {
                    ApplicationName = "Loader",
                    ApplicationBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    DynamicBase = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                    LoaderOptimization = LoaderOptimization.MultiDomainHost,
                    PrivateBinPath = GetPrivateBin(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
                });

            this._loader = (AssemblyLoader)newDomainName.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, typeof(AssemblyLoader).FullName);
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

            foreach (var assembly in loadedAssemblies)
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }

            return null;
        }

        private void WorkClass(string pet, string method)
        {
//            try
//            {
//                object objectResult = this._loader.ExecuteWithConstructor(typeof(IGame), typeof(Pet), method, new object[] { pet }, null);
//                GameResponse gameResponse = (GameResponse)objectResult;
//                return gameResponse;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("There was a problem trying to execute the file", ex);
//            }
        }

        private void LoadData()
        {
            //IF NEEDIT  
        }

        private bool LoadAssembly(byte[] stream)
        {
            try
            {
                this._loader.LoadFromByteArray(stream);
                return true;
            }
            catch (Exception e)
            {
                this._errorMessages.Add(AssemblyErrorMessage);
                return false;
            }


        }

        private void UnloadAssembly(AppDomain domain)
        {
            AppDomain.Unload(domain);
        }
    }
}
