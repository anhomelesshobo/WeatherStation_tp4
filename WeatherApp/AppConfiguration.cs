using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public class AppConfiguration
    {
        static private IConfiguration configuration;

        static public string GetValue(string key)
        {
            string value = null;

            if (configuration==null)
            {
                initConfig();
                
            }

            value = configuration["OWApiKey"];

            return value;
        }

        static private void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            var devEnvVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvVariable) ||
                                    devEnvVariable.ToLower() == "development";

            if (isDevelopment)
            {

                builder.AddUserSecrets<MainWindow>();
            }

            configuration = builder.Build();

        }
    }
}
