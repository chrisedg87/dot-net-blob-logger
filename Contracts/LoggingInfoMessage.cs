namespace Logger
{
    public class LoggingInfoMessage : BaseMessage
    {
        public LoggingInfoMessage()
        {
            PartitionKey = "Info";
        }
    }
}