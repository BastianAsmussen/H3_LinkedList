namespace LinkedList;

public enum Ordering
{
    Ascending,
    Descending
}

public static class MergeSort<T>
{
    public static Element<T>? Sort(Element<T>? head, Ordering ordering)
    {
        if (head?.Next == null)
            return head;

        var middle = GetMiddle(head);
        var nextOfMiddle = middle!.Next;

        middle.Next = null;

        var left = Sort(head, ordering);
        var right = Sort(nextOfMiddle, ordering);

        return MergeParts(left, right, ordering);
    }

    private static Element<T>? MergeParts(Element<T>? left, Element<T>? right, Ordering ordering)
    {
        Element<T>? result;

        if (left == null)
            return right;
        if (right == null)
            return left;

        var comparison = Comparer<T>.Default.Compare(left.Value, right.Value);
        var isSorted = ordering switch
        {
            Ordering.Ascending => comparison <= 0,
            Ordering.Descending => comparison >= 0,
            _ => throw new ArgumentOutOfRangeException(nameof(ordering), ordering, null)
        };

        if (isSorted)
        {
            result = left;
            result.Next = MergeParts(left.Next, right, ordering);
        }
        else
        {
            result = right;
            result.Next = MergeParts(left, right.Next, ordering);
        }

        return result;
    }

    private static Element<T>? GetMiddle(Element<T>? head)
    {
        var slow = head;
        var fast = head;

        while (fast?.Next is { Next: not null })
        {
            slow = slow!.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }
}