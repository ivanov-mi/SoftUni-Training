namespace SolidExersice.Files
{
    using System;
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private const string LogFilePath = @"../../../log.txt";
        public long Size 
        {
            get
            {
                if (File.Exists(LogFilePath))
                {
                    return File.ReadAllText(LogFilePath)
                                .Where(char.IsLetter)
                                .Sum(x => x);
                }

                return 0;
            }
        }

        public void Write(string logMessage)
        {
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }
}
