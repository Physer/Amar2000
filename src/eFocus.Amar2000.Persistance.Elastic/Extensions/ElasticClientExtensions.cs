using System.Linq;
using System.Threading.Tasks;
using eFocus.Amar2000.Persistance.Elastic.Model;
using Nest;

namespace eFocus.Amar2000.Persistance.Elastic.Extensions
{
    public static class ElasticClientExtensions
    {
        public static async Task<bool> SensorExists(this IElasticClient client, ElasticSearchSensor sensor)
        {
            //var response = await client.SearchAsync<ElasticSearchSensor>(s => s
            //                                    .Query(q => q
            //                                        .Bool(b => b
            //                                            .Must(m =>
            //                                                m.Term(t => t.Timestamp, sensor.Timestamp)
            //                                                && m.Nested(n => 
            //                                                    n.Path("zone").Query(nq => 
            //                                                        nq.Bool(nb => nb
            //                                                            .Must(nm => nm
            //                                                                .Term("zone.name", sensor.Zone.Name
                                                                            
                                                                            
            //                                                                )))))))));

            //return response.Hits.Any();

            return false;
        }
    }
}
