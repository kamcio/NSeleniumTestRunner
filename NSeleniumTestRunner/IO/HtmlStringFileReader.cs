using NSeleniumTestRunner.IO.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.IO
{
    public class HtmlStringFileReader : IFileReader
    {
        /// <summary>
        /// Reads the file from path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public FileStream OpenFileForReading(string filePath)
        {
            string errorMessage = String.Empty;
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(filePath);
            }
            catch (PathTooLongException)
            {
                errorMessage = "ERROR: path too long.";
            }
            catch (DirectoryNotFoundException)
            {
                errorMessage = "ERROR: directory not found.";
            }
            catch (UnauthorizedAccessException)
            {
                errorMessage = "ERROR: restricted access.";
            }
            catch (FileNotFoundException)
            {
                errorMessage = "ERROR: file not found.";
            }
            finally
            {
                if (Defaults.VERBOSE_OUTPUT)
                {
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                    }
                    if (fs != null && fs.CanRead)
                    {
                        Console.WriteLine(string.Format("Opened a file for reading from the following path: {0}", filePath));
                    }
                }
            }
            return fs;
        }

        public string ReadStringContentFromFile(string filePath)
        {
            FileStream fs = this.OpenFileForReading(filePath);
            StreamReader reader = new StreamReader(fs);
            string fileText = string.Empty;
            string errorMessage = string.Empty;
            try
            {
                fileText = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                errorMessage = string.Format("ERROR: {0}", e.Message);
            }
            finally
            {
                if (Defaults.VERBOSE_OUTPUT)
                {
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                    }
                }
            }
            return fileText;
        }
    }
}
