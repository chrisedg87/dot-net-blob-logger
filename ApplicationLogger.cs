using System;

namespace Logger
{
    public class ApplicationLogger : IApplicationLogger
    {
        protected IAzureTableStorage<LoggingDebugMessage> _debugRepository;
        protected IAzureTableStorage<LoggingErrorMessage> _errorRepository;
        protected IAzureTableStorage<LoggingInfoMessage> _informationalRepository;
        protected IAzureTableStorage<LoggingWarningMessage> _warningRepository;

        public ApplicationLogger(IAzureTableStorage<LoggingDebugMessage> debugRepository)
        {
            _debugRepository = debugRepository;
        }

        public void Debug(string message)
        {
            var debugMessage = new LoggingDebugMessage()
            {
                Message = message,
                MessageType = MessageType.Debug,
                Timestamp = DateTime.Now
            };

            Debug(debugMessage);
        }

        public void Debug(LoggingDebugMessage message)
        {
            _debugRepository.Insert(message);
        }

        public void Error(string message)
        {
            var errorMessage = new LoggingErrorMessage()
            {
                Message = message,
                MessageType = MessageType.Error,
                Timestamp = DateTime.Now
            };

            Error(errorMessage);
        }

        public void Error(LoggingErrorMessage message)
        {
            _errorRepository.Insert(message);
        }

        public void Informational(string message)
        {
            var infoMessage = new LoggingInfoMessage()
            {
                Message = message,
                MessageType = MessageType.Information,
                Timestamp = DateTime.Now
            };

            Informational(infoMessage);
        }

        public void Informational(LoggingInfoMessage message)
        {
            _informationalRepository.Insert(message);
        } 

        public void Warning(string message)
        {
            var warningMessage = new LoggingWarningMessage()
            {
                Message = message,
                MessageType = MessageType.Warning,
                Timestamp = DateTime.Now
            };

            Warning(warningMessage);
        }

        public void Warning(LoggingWarningMessage message)
        {
            _warningRepository.Insert(message);
        }
    }
}