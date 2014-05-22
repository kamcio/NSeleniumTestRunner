using OpenQA.Selenium;
using NSeleniumTestRunner.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSeleniumTestRunner.TestRunner.TestStrategies;

namespace NSeleniumTestRunner.TestRunner
{
    public class TestCommandsMap
    {
        public Dictionary<string, Type> Map
        {
            get;
            private set;
        }

        public TestCommandsMap()
        {
            this.Map = new Dictionary<string, Type>
            {
                {"open", typeof(OpenPage)},
                {"type", typeof(TypeText)},
                {"click", typeof(Click)},
                // mouse down is bound to click right now (would have to inject some javascript in order to make it work as a mous
                {"mouseDownAt", typeof(Click) },
                {"clickAndWait", typeof(ClickAndWait)},
                {"pause", typeof(Pause)},
                {"waitForPageToLoad", typeof(WaitForPageToLoad)},
                {"sendKeys", typeof(SendKeys)},
                {"verifyTitle", typeof(VerifyTitle)},
                {"verifyElementPresent", typeof(VerifyElementPresent)},
                {"verifyText", typeof(VerifyText)},
                {"waitForElementPresent", typeof(WaitForElementPresent)},
                {"assertAlert", typeof(AssertAlert)},
                {"select", typeof(Select)}
            };
        }
    }
}
