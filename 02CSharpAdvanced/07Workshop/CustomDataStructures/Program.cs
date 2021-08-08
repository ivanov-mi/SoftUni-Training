using System;
using System.Linq;

namespace CustomDataStructures
{
    class Program
    {
        static void Main()
        {
            /*
            //Test custom list
           var list = new CustomList<int>();
           
           for (int i = 0; i < 10; i++)
           {
               list.Add(i);
           }
           
           list.RemoveAt(3);           
           list.Insert(4, 100);
           list.Swap(0, 8);
           
           Console.WriteLine(list.ToString());
           
           list.Reverse();
           
           Console.WriteLine(list.ToString());           
           Console.WriteLine($"Collection contains 100: {list.Contains(100)}");

            //Test custom stack
            var customStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                customStack.Push(i);
            }

            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Peek());

            Console.WriteLine(string.Join(", ", customStack.Where(x => x % 2 == 0)));

            customStack.ForEach(x => Console.WriteLine(x));

            */

            var customDoublyLinkedList = new CustomDoublyLinkedList<int>();
            for (int i = 5; i >= 0; i--)
            {
                customDoublyLinkedList.AddFirst(i);
            }
            for (int i = 60; i < 65; i++)
            {
                customDoublyLinkedList.AddLast(i);
            }

            customDoublyLinkedList.RemoveFirst();
            customDoublyLinkedList.RemoveLast();

            customDoublyLinkedList.ForEach(x => Console.WriteLine(x * 2));

            Console.WriteLine(string.Join(", ", customDoublyLinkedList));
        }
    }
}