using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.Parser
{
    public class TestScenarioContext
    {
        public Uri TestUri { get; set; }
        public IEnumerable<TestItem> TestScenario { get; set; }
    }
}
