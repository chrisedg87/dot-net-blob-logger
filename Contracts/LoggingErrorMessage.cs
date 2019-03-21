namespace Logger
{
    public class LoggingErrorMessage : BaseMessage 
    {
        public LoggingErrorMessage()
        {
            PartitionKey = "Error";
        }
    }
}