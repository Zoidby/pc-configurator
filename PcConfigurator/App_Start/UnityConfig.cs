using System;
using System.Configuration;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using PcConfigurator.Repositories;
using PcConfigurator.Repositories.Mongo;
using PcConfigurator.Service;
using PcConfigurator.Service.Implementation;

namespace PcConfigurator.App_Start
{
    /// <summary>
    ///     Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        ///     There is no need to register concrete types such as controllers or API controllers (unless you want to
        ///     change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            #region Mongo

            var url = ConfigurationManager.ConnectionStrings["MONGO"].ConnectionString;
            var dbName = WebConfigurationManager.AppSettings["dbName"];
            var client = new MongoClient(url);
            var server = client.GetServer();
            var db = server.GetDatabase(dbName);
            container.RegisterInstance(typeof (MongoDatabase), db);

            #endregion

            #region Repositories

            container.RegisterType<ICpuRepository, CpuRepository>();
            container.RegisterType<IGpuRepository, GpuRepository>();
            container.RegisterType<IMemoryRepository, MemoryRepository>();
            container.RegisterType<IPsuRepository, PsuRepository>();
            container.RegisterType<IMotherboardRepository, MotherboardRepository>();
            container.RegisterType<ICaseRepository, CaseRepository>();
            container.RegisterType<IHarddriveRepository, HarddriveRepository>();
            container.RegisterType<IConfigurationRepository, ConfigurationRepository>();

            #endregion

            #region Services

            container.RegisterType<ICpuService, CpuService>();
            container.RegisterType<IGpuService, GpuService>();
            container.RegisterType<IMemoryService, MemoryService>();
            container.RegisterType<IPsuService, PsuService>();
            container.RegisterType<IMotherboardService, MotherboardService>();
            container.RegisterType<ICaseService, CaseService>();
            container.RegisterType<IStorageService, StorageService>();
            container.RegisterType<IConfigurationService, ConfigurationService>();

            #endregion
        }

        #region Unity Container

        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        ///     Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion
    }
}