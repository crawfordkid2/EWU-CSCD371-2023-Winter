using System;
using System.Runtime.CompilerServices;
using static Logger.BaseLogger;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger log, string message, params object[] args) {
            if (log == null)
                throw new System.ArgumentNullException(nameof(log));
            log.Log(LogLevel.Error, string.Format(message, args));
        }
                
        public static void Warning(this BaseLogger log, string message, params object[] args) {
            if (log == null)
                throw new System.ArgumentNullException(nameof(log));
            log.Log(LogLevel.Warning, string.Format(message, args));
        }

        public static void Information(this BaseLogger log, string message, params object[] args) {
            if (log == null)
                throw new System.ArgumentNullException(nameof(log));
            log.Log(LogLevel.Information, string.Format(message, args));
        }

        public static void Debug(this BaseLogger log, string message, params object[] args) {
            if (log == null)
                throw new System.ArgumentNullException(nameof(log));
            log.Log(LogLevel.Debug, string.Format(message, args));
        }
    }
}
