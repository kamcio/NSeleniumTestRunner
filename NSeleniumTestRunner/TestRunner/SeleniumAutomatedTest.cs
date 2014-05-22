using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using NSeleniumTestRunner.Parser;
using NSeleniumTestRunner.TestRunner.Infrastructure;
using NSeleniumTestRunner.Messages;

namespace NSeleniumTestRunner.TestRunner
{
    [TestFixture]
    public class SeleniumAutomatedTest : TestTemplate
    {
        protected IEnumerable<TestItem> testScenario;
        protected IWebDriver driver;
        protected Uri baseUrl;
        protected TestCommandsMap commandsMap;
        protected TestContext testContex;

        private bool acceptNextAlert = true;
        private StringBuilder verificationErrors;

        public SeleniumAutomatedTest(Uri baseUrl, IEnumerable<TestItem> testScenario, IWebDriver driverForTesting, bool acceptNextAlerts = true)
        {
            this.baseUrl = baseUrl;
            this.acceptNextAlert = acceptNextAlerts;
            this.driver = driverForTesting;
            this.testScenario = testScenario;
            this.commandsMap = new TestCommandsMap();
        }

        /// <summary>
        /// Setups the test.
        /// </summary>
        protected override void SetupTest()
        {
            this.verificationErrors = new StringBuilder();
            this.driver.Url = this.baseUrl.ToString();
        }

        /// <summary>
        /// The main body of the test.
        /// </summary>
        /// <returns></returns>
        [Test]
        protected override TestRunResult TestBody()
        {
            TestRunResult result = new TestRunResult();
            {
                result.Status = true;
            }
            Console.Write(Environment.NewLine);
            foreach (var item in this.testScenario)
            {
                Console.Write('.');
                ITestStrategy testStrategy;
                try
                {
                    testStrategy = Activator.CreateInstance(this.commandsMap.Map[item.OperationType]) as ITestStrategy;
                }
                catch (KeyNotFoundException)
                {
                    result.Status = false;
                    result.Message = string.Format("Not supported operation: {0}", item.OperationType);
                    break;
                }
                TestContext testContex = new TestContext(testStrategy);
                var singleItemResult = testContex.ExectueTestStrategy(this.driver, item);
                if (!singleItemResult.Status)
                {
                    result.Status = singleItemResult.Status;
                    result.Message = singleItemResult.Message;
                    verificationErrors.AppendLine(singleItemResult.Message);
                    break;
                }
            }
            if (result.Status)
            {
                result.Message = "OK";
            }
            Console.Write(Environment.NewLine);
            return result;
        }

        /// <summary>
        /// Tears down test.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void TearDownTest()
        {
            //Assert.AreEqual(string.Empty, verificationErrors.ToString());
        }
    }
}
