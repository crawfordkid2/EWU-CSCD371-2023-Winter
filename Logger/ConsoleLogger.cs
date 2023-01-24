using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logger;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger()
        {
            ClassName = nameof(ConsoleLogger);
        }

        public override void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{DateTime.Now} {ClassName} {Enum.GetName(typeof(LogLevel), level)}: {message}");
        }
    }  
}
