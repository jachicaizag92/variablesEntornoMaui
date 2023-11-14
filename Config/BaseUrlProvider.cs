using Microsoft.Extensions.Configuration;

namespace entorno.Config
{
    public class EnvironmentProvider : IEnvironments
    {
        private readonly IConfiguration _configuration;

        public EnvironmentProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetBaseUrl()
        {
            return _configuration.GetValue<string>("BASE_URL");
        }

        public string GetDatabaseConnectionString()
        {
            return _configuration.GetValue<string>("DB_CONNECTION_STRING");
        }
    }

    public interface IEnvironments
    {
        string GetBaseUrl();
        string GetDatabaseConnectionString();

    }

}

