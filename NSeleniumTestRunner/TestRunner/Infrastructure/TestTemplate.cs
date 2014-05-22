using NUnit.Framework;
using OpenQA.Selenium;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.Infrastructure
{
    [TestFixture]
    public abstract class TestTemplate
    {
        protected abstract void SetupTest();
        [Test]
        protected abstract TestRunResult TestBody();
        protected abstract void TearDownTest();

        public TestRunResult RunTest()
        {
            this.SetupTest();
            TestRunResult result = this.TestBody();
            this.TearDownTest();
            return result;
        }
    }
}
