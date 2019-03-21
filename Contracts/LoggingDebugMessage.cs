namespace Logger
{
    public class LoggingDebugMessage : BaseMessage
    {
        public LoggingDebugMessage()
        {
            PartitionKey = "Debug";
        }
    }
}