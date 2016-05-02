using Autofac;
using eFocus.Amar2000.Datasources.Netatmo;
using eFocus.Amar2000.Infrastructure.Services;
using eFocus.Amar2000.Persistance.Elastic;

namespace eFocus.Amar2000.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Modules
            builder.RegisterModule<NetatmoModule>();
            builder.RegisterModule<ElasticModule>();

            builder.RegisterType<ClimateService>();
        }
    }
}
