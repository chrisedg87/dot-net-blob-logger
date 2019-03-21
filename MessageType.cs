using System.ComponentModel;

namespace Logger
{
    public enum MessageType
    {
        [Description("Debug")]
        Debug = 1, 
        [Description("Info")]
        Information = 2, 
        [Description("Warn")]
        Warning = 3,
        [Description("Error")]
        Error = 4
    }
}