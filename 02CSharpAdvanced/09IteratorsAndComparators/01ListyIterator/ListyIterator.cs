using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.elements = list;
            this.index = 0;
        }

        public List<T> List => this.elements;

        public bool Move()
        {
            bool canMoveIndex = this.HasNext();

            if (canMoveIndex)
            {
                this.index++;
            }

            return canMoveIndex;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine($"{this.elements[this.index]}");
        }

        public bool HasNext()
        {
            if (this.index < this.elements.Count - 1)
            {
                return true;
            }

            return false;
        }
    }
}