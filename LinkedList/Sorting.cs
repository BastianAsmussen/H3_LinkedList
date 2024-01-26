namespace LinkedList;

public enum Ordering
{
    Ascending,
    Descending
}

public static class QuickSort<T>
{
    public static T[] Sort(T[] array, Ordering ordering)
    {
        if (array.Length < 2)
            return array;

        Sort(array, 0, array.Length - 1, ordering);

        return array;
    }

    private static void Sort(T[] array, int left, int right, Ordering ordering)
    {
        while (true)
        {
            if (left >= right) return;

            var pivot = Partition(array, left, right, ordering);

            Sort(array, left, pivot - 1, ordering);

            left = pivot + 1;
        }
    }

    private static int Partition(T[] array, int left, int right, Ordering ordering)
    {
        var pivot = array[right];
        var i = left - 1;

        for (var j = left; j < right; j++)
        {
            if (Compare(array[j], pivot, ordering) > 0) continue;

            Swap(array, ++i, j);
        }

        Swap(array, i + 1, right);

        return i + 1;
    }

    private static int Compare(T left, T right, Ordering ordering)
    {
        return ordering switch
        {
            Ordering.Ascending => Comparer<T>.Default.Compare(right, left),
            Ordering.Descending => Comparer<T>.Default.Compare(left, right),
            _ => throw new ArgumentOutOfRangeException(nameof(ordering), ordering, null)
        };
    }

    private static void Swap(IList<T> array, int left, int right)
    {
        (array[left], array[right]) = (array[right], array[left]);
    }
}
