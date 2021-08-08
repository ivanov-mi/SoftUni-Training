namespace SolidExersice.Layouts
{
    using System.Text;

    public class XmlLayout : ILayout
    {
        private const string intent = "\t";

        public string Format
                => this.GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<log>");
            sb.AppendLine(intent + "<date>{0}</date>");
            sb.AppendLine(intent + "<level>{1}</level>");
            sb.AppendLine(intent + "<message>{2}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
