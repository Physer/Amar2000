using Autofac;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Persistance.Elastic.Repositories;

namespace eFocus.Amar2000.Persistance.Elastic
{
    public class ElasticModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ElasticSearchPersistanceRepository>().As<IPersistanceRepository>();
        }
    }
}
