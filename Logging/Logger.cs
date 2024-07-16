using Application.Abstractions.Logging;
using NLog;

namespace Logging
{
    public class Logger : Application.Abstractions.Logging.ILogger
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public void Debug(object message)
        {
            throw new NotImplementedException();
        }

        public void Debug(object message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Error(object message)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, object message)
        {
            logger.Error(exception, message.ToString());
        }

        public void Error(Exception exception)
        {
            logger.Error(exception, null);
        }

        public void Fatal(object message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(object message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Info(object message)
        {
            logger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            logger.Info(message);
        }

        public void Warn(object message)
        {
            throw new NotImplementedException();
        }

        public void Warn(object message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
