using System.Collections.Generic;

namespace eFocus.Amar2000.Infrastructure.Configuration.ZoneSensorMapping
{
    public interface IZoneSensorMapping<out TZones>
        where TZones : IEnumerable<IZoneMap<IEnumerable<ISensorMap>>>
    {
        TZones Zones { get; }
    }
}
