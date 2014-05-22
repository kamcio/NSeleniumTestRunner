using NSeleniumTestRunner.Parser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace NSeleniumTestRunner.Parser
{
    public class SeleniumHtmlParser : ISeleniumHtmlParser
    {
        public TestScenarioContext ParseSeleniumHtmlTests(string htmlString)
        {
            List<TestItem> tmpTestScenario = new List<TestItem>();
            Uri tmpBaseUri;

            TestScenarioContext currentTestContext = new TestScenarioContext();
            
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            // grab the test url from file, otherwise try default url, otherwise exception
            HtmlNode urlNode = htmlDoc.DocumentNode.SelectSingleNode("/html/head/link[@rel='selenium.base']");
            if (urlNode != null)
            {
                tmpBaseUri = new Uri(urlNode.Attributes["href"].Value);
            }
            else
            {
                tmpBaseUri = Defaults.DEFAULT_URL;
            }

            foreach (HtmlNode tableRow in htmlDoc.DocumentNode.SelectNodes("/html/body/table/tbody/tr"))
            {
                HtmlNodeCollection seleniumCommands = tableRow.SelectNodes("td");
                TestItem ti = new TestItem();
                ti.OperationType = seleniumCommands[0].InnerText;
                ti.Selector = seleniumCommands[1].InnerText;
                ti.Value = seleniumCommands[2].InnerText;
                tmpTestScenario.Add(ti);
            }

            currentTestContext.TestScenario = tmpTestScenario;
            currentTestContext.TestUri = tmpBaseUri;

            return currentTestContext;
        }
    }
}
