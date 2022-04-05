using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Configuration
{
    public static class AppSettings
    {
        public static string AuthorityUrl { get; set; } = Helper.GetValueByParent("AppSetting", "AuthorityUrl");
        public static string ClientId { get; set; } = Helper.GetValueByParent("AppSetting", "ClientId");
        public static string ClientSecret { get; set; } = Helper.GetValueByParent("AppSetting", "ClientSecret");
    }
}
