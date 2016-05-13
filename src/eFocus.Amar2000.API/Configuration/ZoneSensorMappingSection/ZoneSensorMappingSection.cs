using System.Configuration;
using eFocus.Amar2000.Infrastructure.Configuration.ZoneSensorMapping;

namespace eFocus.Amar2000.API.Configuration.ZoneSensorMappingSection
{
    public class ZoneSensorMappingSection : ConfigurationSection, IZoneSensorMapping<ZoneCollection>
    {
        static class Constants
        {
            public const string Zones = "zones";
        }

        [ConfigurationProperty(Constants.Zones, IsDefaultCollection = true)]
        public ZoneCollection Zones => (ZoneCollection)base[Constants.Zones];
    }

    [ConfigurationCollection(typeof(ZoneElement), AddItemName = Constants.Zone, CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ZoneCollection : BaseConfigurationElementCollection<ZoneElement>
    {
        static class Constants
        {
            public const string Zone = "zone";
        }

        public ZoneCollection() : base(Constants.Zone, x => x.Name)
        {
        }
    }

    public class ZoneElement : ConfigurationElement, IZoneMap<SensorCollection>
    {
        static class Constants
        {
            public const string Name = "name";
            public const string Sensors = "sensors";
        }

        [StringValidator]
        [ConfigurationProperty(Constants.Name, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[Constants.Name]; }
            set { this[Constants.Name] = value; }
        }

        [ConfigurationProperty(Constants.Sensors, IsDefaultCollection = true)]
        public SensorCollection Sensors => (SensorCollection)base[Constants.Sensors];
    }

    [ConfigurationCollection(typeof(SensorElement), AddItemName = Constants.Sensor, CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class SensorCollection : BaseConfigurationElementCollection<SensorElement>
    {
        static class Constants
        {
            public const string Sensor = "sensor";
        }

        public SensorCollection() : base(Constants.Sensor, x => x.Id)
        {
        }
    }

    public class SensorElement : ConfigurationElement, ISensorMap
    {
        static class Constants
        {
            public const string Id = "id";
            public const string Name = "name";
        }

        [ConfigurationProperty(Constants.Id, IsRequired = true, IsKey = true)]
        public string Id
        {
            get { return (string) this[Constants.Id]; }
            set { this[Constants.Id] = value; }
        }

        [ConfigurationProperty(Constants.Name, IsRequired = true)]
        public string Name
        {
            get { return (string) this[Constants.Name]; }
            set { this[Constants.Name] = value; }
        }
    }


}
