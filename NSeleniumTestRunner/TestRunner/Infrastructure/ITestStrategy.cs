using OpenQA.Selenium;
using NSeleniumTestRunner.Messages;
using NSeleniumTestRunner.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.Infrastructure
{
    public interface ITestStrategy
    {
        BaseResult ExecuteTest(IWebDriver driverToTest, TestItem itemToTest);
    }
}
