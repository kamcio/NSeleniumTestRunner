using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.TestStrategies
{
    public class WaitForElementPresent : Infrastructure.ITestStrategy
    {
        public Messages.BaseResult ExecuteTest(OpenQA.Selenium.IWebDriver driverToTest, Parser.TestItem itemToTest)
        {
            BaseResult br = new BaseResult();
            try
            {
                WebDriverWait waitLock = new WebDriverWait(driverToTest, TimeSpan.FromSeconds(Defaults.TIMEOUT_IN_SECONDS));
                SeleniumHtmlHelper helper = new SeleniumHtmlHelper(driverToTest);
                IWebElement element = waitLock.Until<IWebElement>((x) =>
                    {
                        return helper.ElementLocator(itemToTest.Selector);
                    });
                br.Status = true;
                br.Message = "OK";
            }
            catch (Exception e)
            {
#if DEBUG
                throw;
#endif
                br.Status = false;
                br.Message = string.Format("Exception type: {0}. Message: {1}.", e.GetType(), e.Message);
            }
            return br;
        }
    }
}
