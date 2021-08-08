namespace SolidExersice.Loggers
{
    using Appenders;

    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
    }
}
