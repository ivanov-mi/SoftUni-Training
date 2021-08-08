namespace CommandPattern.Core
{
    using System;
    using Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                var commandInput = Console.ReadLine();
                try
                {
                    var result = this.command.Read(commandInput);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
