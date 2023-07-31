using Microsoft.Extensions.Configuration;

namespace OmegaGymServer.Persistence;

public static class ConnectionConfiguration
{
    public static string ConnectionString
    {
        get
        {
            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //TODO:SetBasePath'i yayınlamak için düzenle ~.
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "~/OmegaGymServer/Presentation/OmegaGymServer.API"));
            //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "/Users/muraterennar/Projects/OmegaGymServer/Presentation/OmegaGymServer.API"));
            configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configurationManager.AddJsonFile($"appsettings.{environment}.json", optional: true);
            configurationManager.AddEnvironmentVariables();

            return configurationManager.GetConnectionString("MsSqlServer");
        }
    }
}

