namespace SolidExersice.Files
{
    public interface ILogFile
    {
        public long Size { get; }

        public void Write(string logMessage);
    }
}
