using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractice
{
public class Logger
    {
        public void LogEntry(string logEntry)
        {
            StreamWriter writer = new StreamWriter("log.txt", true);
            using (writer)
            {
                writer.WriteLine(string.Format("{0} - {1}", DateTime.Now.ToString(), logEntry));
            }
        }
    }
}
