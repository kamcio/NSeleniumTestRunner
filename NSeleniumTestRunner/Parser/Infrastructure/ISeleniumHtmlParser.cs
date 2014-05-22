using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.Parser.Infrastructure
{
    public interface ISeleniumHtmlParser
    {
        TestScenarioContext ParseSeleniumHtmlTests(string htmlString);
    }
}
