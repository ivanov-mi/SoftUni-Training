namespace GenericsExcercise
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 t1Item, T2 t2Item, T3 t3Item)
        {
            this.T1Item = t1Item;
            this.T2Item = t2Item;
            this.T3Item = t3Item;
        }

        public T1 T1Item { get; set; }
        public T2 T2Item { get; set; }
        public T3 T3Item { get; set; }

        public override string ToString()
        {
            return $"{this.T1Item} -> {this.T2Item} -> {this.T3Item}";
        }
    }
}
