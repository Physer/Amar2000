using System.Configuration;

namespace eFocus.Amar2000.API.Configuration
{
    public class ConfigSectionConfigurationRepository : IConfigurationRepository
    {
        public TConfiguration Get<TConfiguration>(string key)
        {
            return (TConfiguration)ConfigurationManager.GetSection(key);
        }
    }
}
