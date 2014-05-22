using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner
{
    public class FlagsHelper
    {
        public static void FlagSwitcher(char flagSymbol)
        {
            switch (flagSymbol)
            {
                case 'v':
                    Defaults.VERBOSE_OUTPUT = true;
                    break;
                default:
                    break;
            }
        }

        public static void HandleFlagsArgument(string flagsArgument)
        {
            if (flagsArgument.StartsWith("-"))
            {
                foreach (char flagSymbol in flagsArgument)
                {
                    FlagsHelper.FlagSwitcher(flagSymbol);
                }
            }
            else
            {
                throw new ArgumentException("Invalid flags argument passed.");
            }
        }
    }
}
