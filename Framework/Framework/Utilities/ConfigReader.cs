using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Framework.Core.Utilities
{
    public static class ConfigReader
    {
        public static string GetBrowser()
        {
            return ConfigurationManager.AppSettings["browser"];
        }
        public static string GetLogfilePath()
        {
            return ConfigurationManager.AppSettings["logfilePath"];
        }
    }
}
