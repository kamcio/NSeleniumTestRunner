using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NSeleniumTestRunner.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.TestRunner.TestStrategies
{
    public class Select : Infrastructure.ITestStrategy
    {
        public Messages.BaseResult ExecuteTest(OpenQA.Selenium.IWebDriver driverToTest, Parser.TestItem itemToTest)
        {
            BaseResult br = new BaseResult();
            try
            {
                SelectElement selectList;
                IWebElement element;
                SeleniumHtmlHelper helper = new SeleniumHtmlHelper(browserDriver: driverToTest);
                element = helper.ElementLocator(itemToTest.Selector);
                selectList = new SelectElement(element);
                if (itemToTest.Value.StartsWith("label="))
                {
                    selectList.SelectByText(itemToTest.Value.Replace("label=", ""));
                }
                else if (itemToTest.Value.StartsWith("value="))
                {
                    selectList.SelectByValue(itemToTest.Value.Replace("value=", ""));
                }
                else if (itemToTest.Value.StartsWith("id="))
                {
                    element.FindElement(By.XPath(string.Format(@"option[@id='{0}']", itemToTest.Value.Replace("id=", ""))));
                }
                else if (itemToTest.Value.StartsWith("index="))
                {
                    int index = int.Parse(itemToTest.Value.Replace("index=", ""));
                    selectList.SelectByIndex(index);
                }

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
