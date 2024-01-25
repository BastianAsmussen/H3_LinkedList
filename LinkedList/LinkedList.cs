namespace LinkedList;

public enum SortOrder
{
    Ascending,
    Descending
}

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

    public void Sort(SortOrder sortOrder = SortOrder.Ascending)
    {
        First = MergeSort(First, sortOrder);
    }

    private Element<T>? MergeSort(Element<T>? head, SortOrder sortOrder)
    {
        if (head?.Next == null)
            return head;

        var middle = GetMiddle(head);
        var nextOfMiddle = middle?.Next;

        if (middle != null)
            middle.Next = null;

        var left = MergeSort(head, sortOrder);
        var right = MergeSort(nextOfMiddle, sortOrder);

        return Merge(left, right, sortOrder);
    }

    private static Element<T>? Merge(Element<T>? left, Element<T>? right, SortOrder sortOrder)
    {
        Element<T>? result;

        if (left == null)
            return right;
        if (right == null)
            return left;

        var comparison = Comparer<T>.Default.Compare(left.Value, right.Value);
        var isSorted = sortOrder switch
        {
            SortOrder.Ascending => comparison <= 0,
            SortOrder.Descending => comparison >= 0,
            _ => throw new ArgumentOutOfRangeException(nameof(sortOrder), sortOrder, null)
        };

        if (isSorted)
        {
            result = left;
            result.Next = Merge(left.Next, right, sortOrder);
        }
        else
        {
            result = right;
            result.Next = Merge(left, right.Next, sortOrder);
        }

        return result;
    }

    private static Element<T>? GetMiddle(Element<T>? head)
    {
        if (head == null)
            return head;

        var slow = head;
        var fast = head;

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return slow;
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
