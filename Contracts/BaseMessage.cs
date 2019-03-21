using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Logger
{
    public class BaseMessage : TableEntity
    {
        public BaseMessage()
        {
            MessageType = MessageType.Audit;
            RowKey = Guid.NewGuid().ToString();
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}