using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDataStructures
{
    public class CustomDoublyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value;
            public ListNode<T> NextNode { get; set; }
            public ListNode<T> PreviousNode { get; set; }
            public ListNode(T value)
            {
                this.Value = value;
            }
        }
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        private void ThrowWhenEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomDoublyLinkedList is empty.");
            }
        }

        public void AddFirst(T element)
        {
            var newHead = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            ThrowWhenEmpty();

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            ThrowWhenEmpty();

            var lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;
            }

            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
        
            for (int i = 0; i < this.Count; i++)
            {
                yield return  currentNode.Value;
        
                currentNode = currentNode.NextNode;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
