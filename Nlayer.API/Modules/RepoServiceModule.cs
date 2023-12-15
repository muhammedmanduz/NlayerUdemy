using Autofac;
using Nlayer.Caching;
using Nlayer.Repository;
using Nlayer.Repository.Repositories;
using Nlayer.Repository.UnitofWork;
using Nlayer.Service.Mapping;
using Nlayer.Service.Services;
using NlayerCore.Repositoies;
using NlayerCore.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Nlayer.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<UnitOfWork>();





            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly=Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
           ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<ProductServiceWithCaching>().As<>





        }
    }
}
