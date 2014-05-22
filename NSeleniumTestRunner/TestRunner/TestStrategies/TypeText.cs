using OpenQA.Selenium;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.TestStrategies
{
    public class TypeText : Infrastructure.ITestStrategy
    {
        public Messages.BaseResult ExecuteTest(OpenQA.Selenium.IWebDriver driverToTest, Parser.TestItem itemToTest)
        {
            BaseResult br = new BaseResult();
            try
            {
                SeleniumHtmlHelper helper = new SeleniumHtmlHelper(browserDriver: driverToTest);
                helper.ElementLocator(itemToTest.Selector).SendKeys(itemToTest.Value);

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
