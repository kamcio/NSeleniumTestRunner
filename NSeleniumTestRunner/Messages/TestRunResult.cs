using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.Messages
{
    /// <summary>
    /// Represents the result of the test that was run.
    /// </summary>
    public class TestRunResult : BaseResult
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Test result: {0}", this.Status ? "OK" : "FAILED"));
            if (!this.Status)
            {
                sb.AppendLine(string.Format("Failure message: {0}", this.Message));
            }
            return sb.ToString();
        }

        public TestRunResult()
        {
            this.Status = false;
            this.Message = string.Empty;
        }
    }
}
