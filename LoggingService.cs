using System;

namespace Putn
{
    public class LoggingService : ILoggingService
    {
        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{logLevel}: {message}");
        }
    }
    
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string message);
    }

    public enum LogLevel { Info, Debug, Warning, Error }
}