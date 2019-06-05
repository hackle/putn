using System;

namespace Putn
{
    public class LoggingService : ILoggingService
    {
        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{logLevel} | {message}");
        }
    }
}