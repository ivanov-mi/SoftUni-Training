namespace CollectionHierarchy.Core
{
    using System;
    using System.Text;
    using Contracts;
    using Models;

    public class Engine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public void Run()
        {
            var stringsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddStrings(stringsInput, addCollection);
            AddStrings(stringsInput, addRemoveCollection);
            AddStrings(stringsInput, myList);

            var numberOfRemoveOperation = int.Parse(Console.ReadLine());

            RemoveStrings(addRemoveCollection, numberOfRemoveOperation);
            RemoveStrings(myList, numberOfRemoveOperation);
        }

        private void RemoveStrings(IAddRemovable collection, int numberOfOperations)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                sb.Append(collection.Remove() + " ");
            }

            var result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        private static void AddStrings(string[] stringsInput, IAddable collection)
        {
            var sb = new StringBuilder();

            foreach (var element in stringsInput)
            {
                var addIndex = collection.Add(element);
                sb.Append(addIndex + " ");
            }

            var result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }
    }
}
