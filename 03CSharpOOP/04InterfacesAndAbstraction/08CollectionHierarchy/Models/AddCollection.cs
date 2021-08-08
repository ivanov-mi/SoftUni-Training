namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public virtual int Add(string element)
        {
            this.Collection.Add(element);

            return this.Collection.Count - 1;
        }
    }
}
