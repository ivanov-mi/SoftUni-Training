namespace CollectionHierarchy.Models
{
    using System;
    using Contracts;

    public class AddRemoveCollection : AddCollection, IAddRemovable
    {
        private const int insertIndex = 0;

        public override int Add(string element)
        {
            this.Collection.Insert(insertIndex, element);

            return insertIndex;
        }

        public virtual string Remove()
        {
            if (this.Collection.Count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var lastElement = this.Collection[this.Collection.Count - 1];
            this.Collection.RemoveAt(this.Collection.Count - 1);

            return lastElement;
        }
    }
}
