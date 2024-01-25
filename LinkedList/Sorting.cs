namespace LinkedList;

public enum Ordering
{
    Ascending,
    Descending
}

public static class QuickSort<T>
{
    public static Element<T>? Sort(Element<T>? head, Ordering ordering)
    {
        if (head?.Next == null)
            return head;

        var pivot = head;
        var current = head.Next;

        Element<T>? left = null;
        Element<T>? right = null;

        while (current != null)
        {
            var next = current.Next;

            if (Compare(current, pivot, ordering))
            {
                current.Next = left;
                left = current;
            }
            else
            {
                current.Next = right;
                right = current;
            }

            current = next;
        }

        left = Sort(left, ordering);
        right = Sort(right, ordering);

        if (left == null)
        {
            pivot.Next = right;
            return pivot;
        }

        var leftTail = LinkedList<T>.GetTail(left);
        leftTail.Next = pivot;
        pivot.Next = right;

        return left;
    }

    private static bool Compare(Element<T> left, Element<T> right, Ordering ordering)
    {
        if (ordering == Ordering.Ascending)
            return Comparer<T>.Default.Compare(left.Value, right.Value) < 0;

        return Comparer<T>.Default.Compare(left.Value, right.Value) > 0;
    }
}
