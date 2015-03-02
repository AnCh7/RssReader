#region Usings

using System;

#endregion

namespace RssReader.Common.Logging
{
    public interface ILogger
    {
        void Error(string message);
        void Error(Exception exception);
        void Error(string message, Exception exception);
        void Warn(string message);
        void Warn(Exception exception);
        void Warn(string message, Exception exception);
        void Info(string message);
        void Info(Exception exception);
        void Info(string message, Exception exception);
        void Debug(string message);
    }
}