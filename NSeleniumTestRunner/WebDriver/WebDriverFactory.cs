using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.WebDriver
{
    public class WebDriverFactory
    {
        public static IWebDriver GetDriver(DriverType typeOfDriver)
        {
            IWebDriver browser;
            switch (typeOfDriver)
            {
                // NOTE REMOTE DRIVER IS NOT SUPPORTED
                case DriverType.Chrome:
                    ChromeOptions co = new ChromeOptions();
                    browser = new ChromeDriver();
                    break;
                case DriverType.IE:
                    InternetExplorerOptions ieo = new InternetExplorerOptions();
                    browser = new InternetExplorerDriver();
                    break;
                case DriverType.Firefox:    
                default:
                    FirefoxProfile ffp = new FirefoxProfile();
                    ffp.AcceptUntrustedCertificates = true;
                    ffp.Port = 8181;

                    browser = new FirefoxDriver(ffp);
                    break;
            }
            return browser;
        }

        public static IWebDriver GetDriver()
        {
            switch (Defaults.DEFAULT_DRIVER)
            {
                case "chrome":
                    return GetDriver(DriverType.Chrome);
                case "ie":
                    return GetDriver(DriverType.IE);
                case "firefox":
                default:
                    return GetDriver(DriverType.Firefox);
            }
        }

        public static async Task<IWebDriver> GetDriverAsync(DriverType typeOfDriver)
        {
            IWebDriver browserDriver;
            switch (typeOfDriver)
            {
                case DriverType.Chrome:
                    ChromeOptions co = new ChromeOptions();
                    browserDriver = await Task.Run(() => new ChromeDriver());
                    break;
                case DriverType.IE:
                    InternetExplorerOptions io = new InternetExplorerOptions();
                    browserDriver = await Task.Run(() => new InternetExplorerDriver());
                    break;
                case DriverType.Firefox:    
                default:
                    FirefoxProfile ffp = new FirefoxProfile();
                    ffp.AcceptUntrustedCertificates = true;
                    FirefoxBinary ffb = new FirefoxBinary(Defaults.FIREFOX_BINARY_PATH);
                    browserDriver = await Task.Run(() => new FirefoxDriver(ffb, ffp));
                    break;
            }
            return browserDriver;
        }
        
        public static async Task<IWebDriver> GetDriverAsync()
        {
            IWebDriver browserDriver;
            switch (Defaults.DEFAULT_DRIVER)
            {
                case "chrome":
                    browserDriver = await GetDriverAsync(DriverType.Chrome);
                    break;
                case "ie":
                    browserDriver = await GetDriverAsync(DriverType.IE);
                    break;
                case "firefox":
                default:
                    browserDriver = await GetDriverAsync(DriverType.Firefox);
                    break;
            }
            return browserDriver;
        }
    }
}
