namespace SolidExersice.Appenders
{
    using Enums;
    using Layouts;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.Count = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        protected int Count { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, " +
                $"Messages appended: {this.Count}";
        }
    }
}
