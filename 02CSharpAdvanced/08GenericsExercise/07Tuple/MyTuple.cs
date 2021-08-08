namespace GenericsExcercise
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 t1Item, T2 t2Item)
        {
            this.T1Item = t1Item;
            this.T2Item = t2Item;
        }

        public T1 T1Item { get; set; }

        public T2 T2Item { get; set; }

        public override string ToString()
        {
            return $"{this.T1Item} -> {this.T2Item}";
        }
    }
}
