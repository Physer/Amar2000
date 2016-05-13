using Autofac;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Datasources.Netatmo;
using eFocus.Amar2000.Infrastructure.Persistance;
using eFocus.Amar2000.Infrastructure.Services;

namespace eFocus.Amar2000.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Modules
            builder.RegisterModule<NetatmoModule>();

            builder.RegisterType<ClimateService>();
            builder.RegisterType<DefaultPeristanceRepository>().As<IPersistanceRepository>();
        }
    }
}
