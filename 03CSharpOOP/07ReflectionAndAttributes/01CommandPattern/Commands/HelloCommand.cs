namespace CommandPattern.Commands
{
    using System;
    using Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Invalid command parameters!");
            }

            return $"Hello, {args[0]}";
        }
    }
}
