using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using eFocus.Amar2000.Infrastructure;

namespace eFocus.Amar2000.API
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register controllers
            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());
            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies());

            // Register modules in the project
            RegisterModules(builder);

            // Register the resolver
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructureModule>();
        }
    }
}
