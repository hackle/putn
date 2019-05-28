namespace Putn
{
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string v);
    }

    public enum LogLevel { Info, Debug, Warning, Error }
}