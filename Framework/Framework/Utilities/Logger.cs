using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Framework.Core.Utilities
{
    public class Logger
    {
        public string FilePath { get; private set; }

        public Logger()
        {
            FilePath = ConfigReader.GetLogfilePath();
        }

        public void LogInfo(string text)
        {
            File.AppendAllText(FilePath, $"{DateTime.Now.ToString()} [INFO]  - {text}\n");
        }

        public void LogError(Exception ex)
        {
            File.AppendAllText(FilePath, $"{DateTime.Now.ToString()} [ERROR] - {ex.GetType()}:{ex.Message}\n{ex.StackTrace}\n");
        }
    }
}
