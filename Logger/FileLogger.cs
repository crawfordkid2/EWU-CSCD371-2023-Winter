using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logger;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public FileLogger(string path)
        {
            FilePath = path;
            ClassName = nameof(FileLogger);
        }
        private string FilePath { get; set; }

        public override void Log(LogLevel level, string message)
        {
            DateTime date = DateTime.Now;
            string outLog = $"{date} {ClassName} {Enum.GetName(typeof(LogLevel), level)}: {message}";
            StreamWriter streamWriter = File.AppendText(FilePath);
            streamWriter.WriteLine(outLog);
            streamWriter.Close();
        }

    }
    
    
}
