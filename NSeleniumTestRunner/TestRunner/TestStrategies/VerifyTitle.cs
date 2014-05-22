using NUnit.Framework;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.TestStrategies
{
    public class VerifyTitle : Infrastructure.ITestStrategy
    {
        public Messages.BaseResult ExecuteTest(OpenQA.Selenium.IWebDriver driverToTest, Parser.TestItem itemToTest)
        {
            BaseResult br = new BaseResult();
            try
            {
                Assert.AreEqual(itemToTest.Selector, driverToTest.Title);

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
