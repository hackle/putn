using System;

namespace Putn
{
    public class LoggingService : ILoggingService
    {
        public void Log(LogLevel logLevel, string message)
        {
            throw new InvalidOperationException($"{nameof(LoggingService)} I.O. is nice but not for tests");
        }
    }
    
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string message);
    }

    public enum LogLevel { Info, Debug, Warning, Error }
}