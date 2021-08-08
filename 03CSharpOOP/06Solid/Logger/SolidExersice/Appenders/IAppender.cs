namespace SolidExersice.Appenders
{
    using Enums;
    using Layouts;

    public interface IAppender
    {
        public ILayout Layout { get;  }

        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
