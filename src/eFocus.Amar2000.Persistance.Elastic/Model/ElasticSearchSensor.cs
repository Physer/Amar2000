using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFocus.Amar2000.Core.Models.Climate;

namespace eFocus.Amar2000.Persistance.Elastic.Model
{
    public class ElasticSearchSensor : Sensor
    {
        public ElasticSearchZone Zone { get; set; }
    }
}
