namespace Putn
{
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string message);
    }

    public enum LogLevel { Info, Debug, Warning, Error }
}