namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Core.Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandInfo = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var commandName = (commandInfo[0] + "Command").ToLower();
            var commandArgs = commandInfo.Skip(1)
                .ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand instanceCommand = (ICommand) Activator.CreateInstance(commandType);

            if (instanceCommand == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var result = instanceCommand.Execute(commandArgs);

            return result;
        }
    }
}
