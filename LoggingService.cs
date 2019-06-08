using System;

namespace Putn
{
    public class LoggingService
    {
        public static void Log(LogLevel logLevel, string message)
        {
            throw new InvalidOperationException($"{nameof(LoggingService)} I.O. is nice but not for tests");
        }
    }
}