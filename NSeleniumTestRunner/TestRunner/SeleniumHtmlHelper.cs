using OpenQA.Selenium;
using NSeleniumTestRunner.TestRunner.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner
{
    public class SeleniumHtmlHelper : IHtmlHelper
    {
        protected IWebDriver driver;

        public SeleniumHtmlHelper(IWebDriver browserDriver)
        {
            this.driver = browserDriver;
        }

        public bool IsElementPresent(By selector)
        {
            try
            {
                this.driver.FindElement(selector);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string GrabTextFromAlertAndClose(bool acceptAlert)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertMessage = alert.Text;
                if (acceptAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertMessage;
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        }

        public IWebElement ElementLocator(string elementLocatorString)
        {
            IWebElement foundElement;
            if (elementLocatorString.StartsWith("id="))
            {
                foundElement = this.driver.FindElement(By.Id(elementLocatorString.Replace("id=", "")));
            }
            else if (elementLocatorString.StartsWith("//"))
            {
                foundElement = this.driver.FindElement(By.XPath(elementLocatorString));
            }
            else if (elementLocatorString.StartsWith("css="))
            {
                foundElement = this.driver.FindElement(By.CssSelector(elementLocatorString.Replace("css=", "")));
            }
            else if (elementLocatorString.StartsWith("link="))
            {
                foundElement = this.driver.FindElement(By.LinkText(elementLocatorString.Replace("link=", "")));
            }
            else if (elementLocatorString.StartsWith("name="))
            {
                foundElement = this.driver.FindElement(By.Name(elementLocatorString.Replace("name=", "")));
            }
            else
            {
                throw new NotSupportedException(string.Format("Not supported selector: {0}", elementLocatorString));
            }
            return foundElement;
        }

        public string GrabTextFromAlertAndClose()
        {
            return GrabTextFromAlertAndClose(true);
        }
    }
}
