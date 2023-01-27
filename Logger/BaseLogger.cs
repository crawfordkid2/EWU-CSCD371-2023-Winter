

namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract void Log(LogLevel level, string message);
        public string? ClassName { get; set; }
    }
}

