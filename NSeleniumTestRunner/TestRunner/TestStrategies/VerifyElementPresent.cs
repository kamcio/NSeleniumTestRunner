using NUnit.Framework;
using OpenQA.Selenium;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.TestStrategies
{
    public class VerifyElementPresent : Infrastructure.ITestStrategy
    {
        /// <summary>
        /// Executes the test.
        /// </summary>
        /// <param name="driverToTest">The driver to test.</param>
        /// <param name="itemToTest">The item to test.</param>
        /// <returns></returns>
        public Messages.BaseResult ExecuteTest(OpenQA.Selenium.IWebDriver driverToTest, Parser.TestItem itemToTest)
        {
            BaseResult br = new BaseResult();
            try
            {
                SeleniumHtmlHelper helper = new SeleniumHtmlHelper(driverToTest);
                IWebElement element = helper.ElementLocator(itemToTest.Selector);
                
                Assert.IsNotNull(element);

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
