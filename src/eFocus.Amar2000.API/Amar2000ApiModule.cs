using System.Collections.Generic;
using Autofac;
using eFocus.Amar2000.API.Configuration;
using eFocus.Amar2000.API.Configuration.ZoneSensorMappingSection;
using eFocus.Amar2000.Infrastructure.Configuration.ZoneSensorMapping;

namespace eFocus.Amar2000.API
{
    public class Amar2000ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigSectionConfigurationRepository>().As<IConfigurationRepository>();

            builder
                .Register(c => c.Resolve<IConfigurationRepository>().Get<ZoneSensorMappingSection>("zoneSensorMapping"))
                .As<IZoneSensorMapping<IEnumerable<IZoneMap<IEnumerable<ISensorMap>>>>>()
                .SingleInstance();
        }
    }
}
