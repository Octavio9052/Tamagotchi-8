using AutoMapper;
using System;
using Tamagotchi.Business;
using Tamagotchi.Business.Business;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.DataAccess.DALs.Interfaces;
using Unity;
using Unity.Configuration;

namespace Tamagotchi.REST
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperConfiguration()); });
//            container.LoadConfiguration();

            container.RegisterInstance<IMapper>(config.CreateMapper());

            container.RegisterType<IPetDAL, PetDAL>();
            container.RegisterType<ISessionDAL, SessionDAL>();
            container.RegisterType<IAnimalDAL, AnimalDAL>();
            container.RegisterType<ILogDAL, LogDAL>();
            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<ILoginDAL, LoginDAL>();

            container.RegisterType<IPetBusiness, PetBusiness>();
            container.RegisterType<ISessionBusiness, SessionBusiness>();
            container.RegisterType<IAnimalBusiness, AnimalBusiness>();
            container.RegisterType<ILogBusiness, LogBusiness>();
            container.RegisterType<IUserBusiness, UserBusiness>();
            container.RegisterType<ILoginBusiness, LoginBusiness>();

        }
    }
}