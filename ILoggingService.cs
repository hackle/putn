namespace Putn
{
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string message);
    }
}