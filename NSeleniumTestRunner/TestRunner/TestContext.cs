using OpenQA.Selenium;
using NSeleniumTestRunner.Messages;
using NSeleniumTestRunner.Parser;
using NSeleniumTestRunner.TestRunner.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner
{
    public class TestContext
    {
        protected ITestStrategy strategy;

        public TestContext(ITestStrategy strategy)
        {
            this.strategy = strategy;
        }

        public BaseResult ExectueTestStrategy(IWebDriver webDriver, TestItem itemToTest)
        {
            return this.strategy.ExecuteTest(webDriver, itemToTest);
        }
    }
}
