using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSeleniumTestRunner.IO.Infrastructure
{
    public interface IFileReader
    {
        FileStream OpenFileForReading(string filePath);
        string ReadStringContentFromFile(string filePath);
    }
}
