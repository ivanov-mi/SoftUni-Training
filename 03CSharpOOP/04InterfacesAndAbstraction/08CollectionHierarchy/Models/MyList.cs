namespace CollectionHierarchy.Models
{
    using System;
    using Contracts;

    public class MyList : AddRemoveCollection, IMyList
    {
        private const int removeIndex = 0;

        public override string Remove()
        {
            if (this.Collection.Count <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var firstElement = this.Collection[removeIndex];
            Collection.RemoveAt(removeIndex);

            return firstElement;
        }
        public int Used => this.Collection.Count;
    }
}
