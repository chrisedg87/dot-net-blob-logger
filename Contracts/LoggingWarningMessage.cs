namespace Logger
{
    public class LoggingWarningMessage : BaseMessage
    {
        public LoggingWarningMessage()
        {
            PartitionKey = "Warn";
        }
    }
}