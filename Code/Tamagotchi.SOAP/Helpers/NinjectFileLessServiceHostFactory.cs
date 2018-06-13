using System.ServiceModel;
using AutoMapper;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Wcf;
using Tamagotchi.Business.Business;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Business.Services;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.SOAP.Helpers
{
    public class NinjectFileLessServiceHostFactory: NinjectServiceHostFactory
    {
        public NinjectFileLessServiceHostFactory()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            //EXTRAS DAL
            kernel.Bind<TamagotchiMongoClient>().To<TamagotchiMongoClient>();
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

            //BUSINESS INSTANCES
            kernel.Bind<ISessionBusiness>().To<SessionBusiness>();
            kernel.Bind<ILoginBusiness>().To<LoginBusiness>();
            kernel.Bind<IUserBusiness>().To<UserBusiness>();
            kernel.Bind<IAnimalBusiness>().To<AnimalBusiness>();


            kernel.Bind<ISOAPService>().To<SOAPService>();
            SetKernel(kernel);
        }
        private static IMapper AutoMapper(IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

            });
            return Mapper.Instance;
        }
    }
}