namespace SolidExersice.Core
{
    using System;

    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;
        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < numberOfAppenders; i++)
                {
                    var appenderInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    this.commandInterpreter.Read(appenderInfo);
                }

                string input = Console.ReadLine();

                while (true)
                {
                    var inputInfo = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    this.commandInterpreter.Read(inputInfo);

                    if (input == "END")
                    {
                        break;
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
