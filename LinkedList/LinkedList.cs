namespace LinkedList;

public class LinkedList<T>(Element<T>? first = null)
{
    private Element<T>? First { get; set; } = first;

    public void AddFirst(Element<T> element)
    {
        element.Next = First;

        First = element;
    }

    public void RemoveFirst() => First = First?.Next;
    public void Clear() => First = null;
    public bool IsEmpty() => First == null;

    public int Count()
    {
        var count = 0;
        var current = First;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    public Element<T>? Get(int index)
    {
        var current = First;
        var count = 0;

        while (current != null)
        {
            if (count == index)
                return current;

            count++;
            current = current.Next;
        }

        return null;
    }

    public Element<T>? GetTail()
    {
        return First?.GetTail();
    }

    public void Sort(Ordering ordering = Ordering.Ascending)
    {
        FromArray(QuickSort<T>.Sort(ToArray(), ordering));
    }

    public void Reverse()
    {
        Element<T>? previous = null;
        var current = First;

        while (current != null)
        {
            var next = current.Next;

            current.Next = previous;

            previous = current;
            current = next;
        }

        First = previous;
    }

    private T[] ToArray()
    {
        var array = new T[Count()];
        var current = First;
        var index = 0;

        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }

        return array;
    }

    private void FromArray(IEnumerable<T> array)
    {
        Clear();

        foreach (var element in array)
            AddFirst(new Element<T>(element));
    }

    public override string ToString() => string.Join(" -> ", First);

    public static LinkedList<int> GenerateRandom(int count)
    {
        var rand = new Random();

        var linkedList = new LinkedList<int>();
        for (var i = 0; i < count; i++)
        {
            var element = new Element<int>(rand.Next());

            linkedList.AddFirst(element);
        }

        return linkedList;
    }
}

public class Element<T>(T value, Element<T>? next = null)
{
    public T Value { get; } = value;
    public Element<T>? Next { get; set; } = next;

    public Element<T>? GetTail()
    {
        var current = this;

        while (current?.Next != null)
            current = current.Next;

        return current;
    }

    public override string ToString() => $"{Value}{(Next != null ? $" -> {Next}" : "")}";
}
