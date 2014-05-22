using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.Messages
{
    public class BaseResult
    { 
        /// <summary>
        /// Gets or sets a value indicating whether [status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [status]; otherwise, <c>false</c>.
        /// </value>
        public bool Status { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
