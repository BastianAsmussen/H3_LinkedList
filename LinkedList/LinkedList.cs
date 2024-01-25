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

    public static Element<T> GetTail(Element<T> head)
    {
        var current = head;

        while (current.Next != null)
            current = current.Next;

        return current;
    }

    public void Sort(Ordering ordering = Ordering.Ascending)
    {
        First = QuickSort<T>.Sort(First, ordering);
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

    public override string ToString() => string.Join(" -> ", First);

    public static LinkedList<int> GenerateRandom(int count)
    {
        var rand = new Random();

        var linkedList = new LinkedList<int>();
        for (var i = 0; i < count; i++)
        {
            var element = new Element<int>(rand.Next(-count, count));

            linkedList.AddFirst(element);
        }

        return linkedList;
    }
}

public class Element<T>(T value, Element<T>? next = null)
{
    public T Value { get; } = value;
    public Element<T>? Next { get; set; } = next;
    
    public override string ToString() => $"{Value}{(Next != null ? $" -> {Next}" : "")}";
}
