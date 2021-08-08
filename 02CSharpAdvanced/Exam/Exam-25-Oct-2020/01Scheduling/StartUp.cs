using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class StartUp
    {
        static void Main()
        {
            var inputTasks = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var tasks = new Stack<int>(inputTasks);

            var inputThreads = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var threads = new Queue<int>(inputThreads);

            var taskToBeKilled = int.Parse(Console.ReadLine());

            while (tasks.Peek() != taskToBeKilled)
            {
                var currentTask = tasks.Peek();
                var currentThread = threads.Dequeue();

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
