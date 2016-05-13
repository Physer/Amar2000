namespace eFocus.Amar2000.API.Configuration
{
    public interface IConfigurationRepository
    {
        TConfiguration Get<TConfiguration>(string key);
    }
}