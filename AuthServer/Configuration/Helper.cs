using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Configuration
{
    public static class Helper
    {
        public static string GetValueByParent(string parent, string Key)
        {
            return GetCurrentSettings().GetSection(parent).GetValue<string>(Key);
        }
        private static IConfigurationRoot GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
