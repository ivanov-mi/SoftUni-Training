using System;
using System.Collections.Generic;

namespace GenericsExcercise
{
    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.Values = new List<T>();
        }
        public List<T> Values { get; set; }

        public int CountGreaterValues(T valueToCompare)
        {
            int count = 0;
            foreach (var item in this.Values)
            {
                if (valueToCompare.CompareTo(item) < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
