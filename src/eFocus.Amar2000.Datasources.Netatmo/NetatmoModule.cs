using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Datasources.Netatmo.Repositories;
using eFocus.Amar2000.Datasources.Netatmo.Session;

namespace eFocus.Amar2000.Datasources.Netatmo
{
    public class NetatmoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NetatmoSessionProvider>().SingleInstance();
            builder.RegisterType<NetatmoClimateRepository>().As<IClimateRepository>();
        }
    }
}
