using System;

namespace Putn
{
    public class LoggingService
    {
        public void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{logLevel}: {message}");
        }
    }
    
    public enum LogLevel { Info, Debug, Warning, Error }
}