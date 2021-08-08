namespace SolidExersice.Appenders
{
    using System;
    using Enums;
    using Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                var logMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);

                Console.WriteLine(logMessage);
                this.Count++;
            }
        }
    }
}
