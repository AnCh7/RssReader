#region Usings

using System;
using System.Reflection;
using log4net;

#endregion

namespace RssReader.Common.Logging
{
    public class Logger : ILogger
    {
        private readonly ILog _log;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Logger" /> class.
        /// </summary>
        public Logger()
        {
            //var targetFile = new TargetFile();
            //targetFile.Setup();

            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(Exception exception)
        {
            _log.Error(exception);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Warn(Exception exception)
        {
            _log.Warn(exception);
        }

        public void Warn(string message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(Exception exception)
        {
            _log.Info(exception);
        }

        public void Info(string message, Exception exception)
        {
            _log.Info(message, exception);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }
    }
}