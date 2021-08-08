using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.count = 0;
            this.items = new T[InitialCapacity];
        }
        public int Count => this.count;

        public void Push(T element)
        {
            EnsureCapacity();
            this.items[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            ThrowWhenEmpty();
            var lastElement = this.items[this.count - 1];
            this.items[this.count - 1] = default;
            this.count--;

            return lastElement;
        }
        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[this.count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void EnsureCapacity()
        {
            if (this.Count == this.items.Length)
            {
                var tempArr = new T[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    tempArr[i] = this.items[i];
                }

                this.items = tempArr;
            }
        }
        private void ThrowWhenEmpty()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
