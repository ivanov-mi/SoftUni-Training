using System;
using System.Text;

public class CustomList<T>
{
    private const int InitialCapacity = 2;

    private T[] items;

    public CustomList()
    {
        this.items = new T[InitialCapacity];
        this.Count = 0;
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return items[index];
        }
        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            items[index] = value;
        }
    }

    private void Resize()
    {
        var copyArray = new T[this.items.Length*2];
        for (int i = 0; i < this.items.Length; i++)
        {
            copyArray[i] = this.items[i];
        }

        this.items = copyArray;
    }

    private void Shrink()
    {
        var copyArray = new T[this.items.Length / 2];
        for (int i = 0; i < this.items.Length; i++)
        {
            copyArray[i] = this.items[i];
        }

        this.items = copyArray;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.items[i] = this.items[i + 1];
        }

        this.items[this.Count - 1] = default;
    }

    private void ShiftRight(int index)
    {
        for (int i = this.Count - 1; i >= index; i--)
        {
            this.items[i] = this.items[i - 1];
        }
    }

    public void Add(T element)
    {
        if (this.Count >= this.items.Length)
        {
            this.Resize();
        }

        this.items[this.Count] = element;
        this.Count++;
    }

    public T RemoveAt(int index)
    {
        if (index >= this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var element = this.items[index];
        this.ShiftLeft(index);
        this.Count--;
        if (this.Count <= this.items.Length / 4)
        {
            this.Shrink();
        }

        return element;
    }

    public void Insert(int index, T element)
    {
        if (index > this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (this.Count >= this.items.Length)
        {
            this.Resize();
        }

        this.Count++;
        this.ShiftRight(index);
        this.items[index] = element; 
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.items[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        if (firstIndex >= this.Count || firstIndex < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (secondIndex >= this.Count || secondIndex < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var tmp = this.items[secondIndex];
        this.items[secondIndex] = this.items[firstIndex];
        this.items[firstIndex] = tmp;
    }

    public void Reverse()
    {
        for (int i = 0; i < this.Count / 2; i++)
        {
            this.Swap(i, this.Count - i - 1);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < this.Count; i++)
        {
            sb.Append($"{this.items[i]}, ");
        }
        
        return sb.ToString().TrimEnd(' ', ',');
    }
}