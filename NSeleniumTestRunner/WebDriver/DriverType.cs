using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.WebDriver
{
    /// <summary>
    /// Represents the available selenium browser driver types.
    /// </summary>
    public enum DriverType
    {
        /// <summary>
        /// Currently not supported
        /// </summary>
        Remote,
        /// <summary>
        /// Chrome browser driver
        /// </summary>
        Chrome,
        /// <summary>
        /// Firefox browser driver
        /// </summary>
        Firefox,
        /// <summary>
        /// Internet Explorer browser driver
        /// </summary>
        IE
    }
}
