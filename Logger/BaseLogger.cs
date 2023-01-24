//using static Logger.BaseLoggerMixins;

namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract void Log(LogLevel level, string message);
        public static string ClassName { get; set; }
    }
   
}
