using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NSeleniumTestRunner.IO;
using NSeleniumTestRunner.IO.Infrastructure;
using NSeleniumTestRunner.Messages;
using NSeleniumTestRunner.Parser;
using NSeleniumTestRunner.Parser.Infrastructure;
using NSeleniumTestRunner.TestRunner;
using NSeleniumTestRunner.TestRunner.Infrastructure;
using NSeleniumTestRunner.WebDriver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner
{
    class Program
    {
        public static IWebDriver browser;

        static void Main(string[] args)
        {
            string filePathOrFileName = string.Empty;
            string flags = string.Empty;

            Console.WriteLine("NSeleniumTestRunner v{0}", Defaults.VERSION);
            if (args.Length == 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Usage:");
                sb.AppendLine("NSeleniumTestRunner.exe -flags <filePath>");
                sb.Append(Environment.NewLine);
                sb.AppendLine("Flags:");
                sb.AppendLine("\t-v\t:\tVerbose output, display all error and trace info.");
                sb.Append(Environment.NewLine);
                sb.AppendLine("Example:");
                sb.AppendLine("NSeleniumTestRunner.exe -v C:\\Test\\example.html");
                Console.Write(sb.ToString());
                return;
            }
            else
            {
                if (args.Length == 2)
                {
                    flags = args[0];
                    filePathOrFileName = args[1];
                    try
                    {
                        FlagsHelper.HandleFlagsArgument(flags);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine("Error: {0}. Exiting.", ae.Message);
                        return;
                    }
                }
                else
                {
                    filePathOrFileName = args[0];
                }
                filePathOrFileName.Trim('"');
                if (!Path.IsPathRooted(filePathOrFileName))
                {
                    filePathOrFileName = Directory.GetCurrentDirectory().TrimEnd('\\') + "\\" + filePathOrFileName;
                }

            }

            // init
            IFileReader fileReader = new HtmlStringFileReader();
            ISeleniumHtmlParser htmlParser = new SeleniumHtmlParser();
            SeleniumAutomatedTest automatedTestProcedure;
            browser = WebDriverFactory.GetDriver();
            browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Defaults.TIMEOUT_IN_SECONDS));
            
            // READ FILE
            string testHtml = fileReader.ReadStringContentFromFile(filePath: filePathOrFileName);
            // PARSE
            TestScenarioContext testScenario = htmlParser.ParseSeleniumHtmlTests(testHtml);

            if (Defaults.VERBOSE_OUTPUT)
            {
                Console.WriteLine(string.Format("Test scenario loaded. Number of steps: {0}", testScenario.TestScenario.Count()));
            }
            //RUN TESTS
            Console.WriteLine("Starting the test procedure, please wait...");
            Stopwatch counter = new Stopwatch();
            try
            {
                // init the test procedure class
                automatedTestProcedure = new SeleniumAutomatedTest(testScenario.TestUri, testScenario.TestScenario, browser);
                counter.Start();
                TestRunResult testResult = automatedTestProcedure.RunTest();
                counter.Stop();
                Console.WriteLine(string.Format("Test run finished, time elapsed : {0} s", counter.Elapsed.Seconds));
                Console.WriteLine(testResult.ToString());
            }
            catch (UriFormatException)
            {
                Console.WriteLine("ERROR: Base URI configuration is invalid, chceck app.config. Exiting.");
                return;
            }
            finally
            {
                if (browser != null)
                {
                    browser.Quit();
                }
            }
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
