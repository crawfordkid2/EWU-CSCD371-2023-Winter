using System;

namespace Logger
{
    public class LogFactory
    {   
        private string? filePath;

        public BaseLogger? CreateLogger(string className) {
            if (className != null)
            {
                if (className.Equals(nameof(FileLogger), StringComparison.Ordinal))
                {
                    if (filePath != null)
                    {
                        var fileLogger = new FileLogger(filePath);
                        fileLogger.ClassName = nameof(FileLogger);
                        return fileLogger;
                    }
                }
                else if (className.Equals(nameof(ConsoleLogger), StringComparison.Ordinal))
                {
                    var consoleLogger = new ConsoleLogger();
                    consoleLogger.ClassName = nameof(ConsoleLogger);
                    return consoleLogger;
                }
            }
            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
