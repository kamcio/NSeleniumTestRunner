using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.Infrastructure
{
    public interface IHtmlHelper
    {
        bool IsElementPresent(By selector);
        bool IsAlertPresent();
        string GrabTextFromAlertAndClose();
        string GrabTextFromAlertAndClose(bool acceptNextAlert);
    }
}
