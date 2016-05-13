using System.Collections.Generic;

namespace eFocus.Amar2000.Infrastructure.Configuration.ZoneSensorMapping
{
    public interface IZoneMap<out TSensors>
        where TSensors : IEnumerable<ISensorMap>
    {
        string Name { get; set; }
        TSensors Sensors { get; } 
    }
}
