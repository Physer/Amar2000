using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFocus.Amar2000.Core.Models.Climate
{
    public class Zone
    {
        public string Name { get; set; }
        public IEnumerable<Sensor> Sensors { get; set; }
    }
}
