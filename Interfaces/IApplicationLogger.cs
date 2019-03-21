namespace Logger
{
    public interface IApplicationLogger
    {
        void Debug(string message);
        void Debug(LoggingDebugMessage message);
    }
}