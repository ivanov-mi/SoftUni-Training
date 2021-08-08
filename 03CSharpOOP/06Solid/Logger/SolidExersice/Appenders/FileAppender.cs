namespace SolidExersice.Appenders
{
    using Enums;
    using Files;
    using Layouts;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile) 
            :base(layout)
        {
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                var logMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);

                this.LogFile.Write(logMessage);
                Count++;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" File size: {this.LogFile.Size}";
        }
    }
}
