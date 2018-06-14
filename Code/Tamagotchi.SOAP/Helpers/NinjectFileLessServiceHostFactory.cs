using AutoMapper;
using Ninject;
using Ninject.Extensions.Wcf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Tamagotchi.Business;
using Tamagotchi.Business.Business;
using Tamagotchi.Business.Helpers;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Business.Services;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Tamagotchi.SOAP.App_Start;

namespace Tamagotchi.SOAP.Helpers
{
    public class NinjectFileLessServiceHostFactory: NinjectServiceHostFactory
    {
        public NinjectFileLessServiceHostFactory()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            //EXTRAS DAL
            kernel.Bind<TamagotchiMongoClient>().To<TamagotchiMongoClient>().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["Tamagotchi9052MongoDBConnString"].ConnectionString);
            kernel.Bind<TamagotchiContext>().To<TamagotchiContext>();

            //DAL INSTANCES
            kernel.Bind<IUserDAL>().To<UserDAL>();
            kernel.Bind<IAnimalDAL>().To<AnimalDAL>();
            kernel.Bind<ISessionDAL>().To<SessionDAL>();
            kernel.Bind<ILogDAL>().To<LogDAL>();
            kernel.Bind<ILoginDAL>().To<LoginDAL>();

            //Extras
            kernel.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
            kernel.Bind<CloudService>().To<CloudService>();
            kernel.Bind<StorageService>().To<StorageService>().WithConstructorArgument("storageConnectionString", ConfigurationManager.ConnectionStrings["TamagotchiStorage"].ConnectionString); ;

            //BUSINESS INSTANCES
            kernel.Bind<ISessionBusiness>().To<SessionBusiness>();
            kernel.Bind<ILoginBusiness>().To<LoginBusiness>();
            kernel.Bind<IUserBusiness>().To<UserBusiness>();
            kernel.Bind<IAnimalBusiness>().To<AnimalBusiness>();


            kernel.Bind<ISOAPService>().To<SOAPService>();
            SetKernel(kernel);
        }
        private static IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new AutomapperProfile());

            });
            return Mapper.Instance;
        }
    }
}