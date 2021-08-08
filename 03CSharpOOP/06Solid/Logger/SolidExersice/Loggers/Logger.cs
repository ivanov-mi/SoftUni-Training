namespace SolidExersice.Models
{
    using System;
    using Appenders;
    using Enums;
    using Loggers;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders 
        {
            get
            {
                return this.appenders;
            } 
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "value cannot be null");
                }

                this.appenders = value;
            }
        }

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.INFO, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.WARNING, message);
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.ERROR, message);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.CRITICAL, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.FATAL, message);
        }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
