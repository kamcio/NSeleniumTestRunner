using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NSeleniumTestRunner
{
    public class Defaults
    {
        public static double VERSION { get { return double.Parse(ConfigurationManager.AppSettings["version"]); } }
        public static bool VERBOSE_OUTPUT { get; set; }
        public static string FIREFOX_BINARY_PATH { get { return ConfigurationManager.AppSettings["driver:firefoxBinaryPath"]; } }
        public static Uri DEFAULT_URL { get { return new Uri(ConfigurationManager.AppSettings["driver:baseUrl"]); } }
        public static string DEFAULT_DRIVER { get { return ConfigurationManager.AppSettings["driver:defaultDriver"]; } }
        public static int TIMEOUT_IN_SECONDS
        {
            get
            {
                int timeoutInSeconds = 0;
                bool parseResult = int.TryParse(ConfigurationManager.AppSettings["timeoutseconds"], out timeoutInSeconds);
                if (!parseResult)
                {
                    timeoutInSeconds = 10;
                }
                return timeoutInSeconds;
            }
        }
    }
}
