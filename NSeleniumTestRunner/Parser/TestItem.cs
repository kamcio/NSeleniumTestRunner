using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.Parser
{
    public class TestItem
    {
        public string OperationType { get; set; }
        public string Selector { get; set; }
        public string Value { get; set; }
    }
}
