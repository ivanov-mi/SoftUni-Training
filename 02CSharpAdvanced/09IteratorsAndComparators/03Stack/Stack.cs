using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] elements;
        private int count;

        public Stack()
        {
            this.elements = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count => this.count;

        public void Push(T element)
        {
            this.EnsureCapacity();
            this.elements[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            this.ThrowWhenEmpty();
            var lastElement = this.elements[this.count - 1];
            this.elements[this.count - 1] = default;
            this.count--;
            this.ReduceCapacity();

            return lastElement;
        }

        private void EnsureCapacity()
        {
            if (this.count < this.elements.Length)
            {
                return;
            }

            var tempArr = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                tempArr[i] = this.elements[i];
            }

            this.elements = tempArr;
        }

        private void ReduceCapacity()
        {
            if (this.count > 0.25 * this.elements.Length)
            {
                return;
            }

            var tempArr = new T[this.elements.Length / 2];
            for (int i = 0; i < this.elements.Length / 2; i++)
            {
                tempArr[i] = this.elements[i];
            }

            this.elements = tempArr;
        }

        private void ThrowWhenEmpty()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}