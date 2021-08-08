namespace SolidExersice.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders;
    using Enums;
    using Factories;
    using Layouts;
    using Loggers;
    using Models;

    public class CommandInterpreter
    {
        private readonly List<IAppender> appenders;
        private ILogger logger;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        public void Read(string[] args)
        {
            string command = args[0];

            if (command.Contains("Appender"))
            {
                CreateAppender(args);
            }
            else if (Enum.IsDefined(typeof(ReportLevel), command))
            {
                logger = new Logger(appenders.ToArray());
                AppendMessage(args);
            }
            else if (command == "END")
            {
                PrintInfo();
            }
        }

        private void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

        private void CreateAppender(string[] inputInfo)
        {
            var appenderType = inputInfo[0];
            var layoutType = inputInfo[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (inputInfo.Length > 2)
            {
                reportLevel = Enum.Parse<ReportLevel>(inputInfo[2], true);
            }

            ILayout layout = LayoutFactory.CreateLayout(layoutType);
            IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
            appenders.Add(appender);
        }

        private void AppendMessage(string[] inputInfo)
        {
            var loggerReportLevel = inputInfo[0];
            var date = inputInfo[1];
            var message = inputInfo[2];

            switch (loggerReportLevel)
            {
                case "INFO":
                    logger.Info(date, message);
                    break;
                case "WARNING":
                    logger.Warning(date, message);
                    break;
                case "ERROR":
                    logger.Error(date, message);
                    break;
                case "CRITICAL":
                    logger.Critical(date, message);
                    break;
                case "FATAL":
                    logger.Fatal(date, message);
                    break;
            }
        }
    }
}
