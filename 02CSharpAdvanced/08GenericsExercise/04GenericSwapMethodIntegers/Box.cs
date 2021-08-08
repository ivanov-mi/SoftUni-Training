using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsExcercise
{
    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public void Swap(int a, int b)
        {
            ThrowIfEmpty();
            CheckIndexesOutOfRange(a, b);

            T temp = this.Values[a];
            this.Values[a] = this.Values[b];
            this.Values[b] = temp;
        }

        private void ThrowIfEmpty()
        {
            if (this.Values.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
        }
        private void CheckIndexesOutOfRange(int a, int b)
        {
            bool isOutOfRange = a < 0 || a >= this.Values.Count || b < 0 || b >= this.Values.Count;

            if (isOutOfRange)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");

            }

            var result = sb.ToString().Trim();

            return result;
        }
    }
}
