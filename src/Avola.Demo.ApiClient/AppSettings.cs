using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avola.Demo.ApiClient
{
    public class AppSettings
    {
        private static string Get(string name, string defaultValue = null)
        {
            var result = ConfigurationManager.AppSettings[name];
            return result ?? defaultValue;
        }

        private static bool GetBool(string name, bool defaultValue = false)
        {
            var result = defaultValue;
            bool.TryParse(Get(name), out result);
            return result;
        }
        public class Authentication
        {
            public static string Url => Get("authentication.url");

            public static string Scope => Get("authentication.scope", "avola-api-client");

            public static bool ValidateAllServerCertificates => GetBool("authentication.validateallservercertificates");
        }
    }

}
