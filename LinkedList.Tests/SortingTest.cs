using System.Reflection;

namespace LinkedList.Tests;

public class SortingTest
{
    [Test]
    public void TestSortAscending()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        Assert.That(linkedList.ToString(), Is.EqualTo("2 -> 3 -> 1"));

        linkedList.Sort();
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 2 -> 3"));
    }

    [Test]
    public void TestSortDescending()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        Assert.That(linkedList.ToString(), Is.EqualTo("2 -> 3 -> 1"));

        linkedList.Sort(Ordering.Descending);
        Assert.That(linkedList.ToString(), Is.EqualTo("3 -> 2 -> 1"));
    }

    [Test]
    public void TestSortNull()
    {
        Assert.That(MergeSort<int>.Sort(null, Ordering.Ascending), Is.Null);
    }

    [Test]
    public void TestSortNoNext()
    {
        var element = new Element<int>(1);

        Assert.Multiple(() =>
        {
            Assert.That(element.Next, Is.Null);
            Assert.That(MergeSort<int>.Sort(element, Ordering.Ascending)?.ToString(), Is.EqualTo("1"));
        });
    }

    [Test]
    public void TestSortOneElement()
    {
        var element = new Element<int>(1);

        Assert.Multiple(() =>
        {
            Assert.That(element.Next, Is.Null);
            Assert.That(MergeSort<int>.Sort(element, Ordering.Ascending)?.ToString(), Is.EqualTo("1"));
        });
    }

    [Test]
    public void TestMergeParts()
    {
        var left = new Element<int>(1)
        {
            Next = new Element<int>(3)
        };
        left.Next.Next = new Element<int>(5);

        var right = new Element<int>(2)
        {
            Next = new Element<int>(4)
        };
        right.Next.Next = new Element<int>(6);

        var method = typeof(MergeSort<int>).GetMethod("MergeParts", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [left, right, Ordering.Ascending]);

        Assert.That(result?.ToString(), Is.EqualTo("1 -> 2 -> 3 -> 4 -> 5 -> 6"));
    }

    [Test]
    public void TestMergePartsInvalidOrdering()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Sort((Ordering)2));
    }

    [Test]
    public void TestGetMiddle()
    {
        var head = new Element<int>(1)
        {
            Next = new Element<int>(2)
        };

        var method = typeof(MergeSort<int>).GetMethod("GetMiddle", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [head]);

        Assert.That(result?.ToString(), Is.EqualTo("1 -> 2"));
    }

    [Test]
    public void TestGetMiddleNull()
    {
        var method = typeof(MergeSort<int>).GetMethod("GetMiddle", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [null]);

        Assert.That(result, Is.Null);

        var head = new Element<int>(1);
        result = method?.Invoke(null, [head]);

        Assert.That(result, Is.EqualTo(head));
    }

    [Test]
    public void TestGetMiddleEvenElements()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(4));

        var method = typeof(MergeSort<int>).GetMethod("GetMiddle", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [linkedList.Get(0)]);

        Assert.That(result?.ToString(), Is.EqualTo("3 -> 2 -> 1"));
    }

    [Test]
    public void TestGetMiddleOddElements()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(4));
        linkedList.AddFirst(new Element<int>(5));

        var method = typeof(MergeSort<int>).GetMethod("GetMiddle", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [linkedList.Get(0)]);

        Assert.That(result?.ToString(), Is.EqualTo("3 -> 2 -> 1"));
    }

    [Test]
    public void TestSortSameElements()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(1));
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 1 -> 1"));

        linkedList.Sort();
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 1 -> 1"));
    }

    [Test]
    public void TestMergePartsAllSmaller()
    {
        var left = new Element<int>(1)
        {
            Next = new Element<int>(2)
        };
        left.Next.Next = new Element<int>(3);

        var right = new Element<int>(4)
        {
            Next = new Element<int>(5)
        };
        right.Next.Next = new Element<int>(6);

        var method = typeof(MergeSort<int>).GetMethod("MergeParts", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [left, right, Ordering.Ascending]);

        Assert.That(result?.ToString(), Is.EqualTo("1 -> 2 -> 3 -> 4 -> 5 -> 6"));
    }

    [Test]
    public void TestMergePartsAllLarger()
    {
        var left = new Element<int>(4)
        {
            Next = new Element<int>(5)
        };
        left.Next.Next = new Element<int>(6);

        var right = new Element<int>(1)
        {
            Next = new Element<int>(2)
        };
        right.Next.Next = new Element<int>(3);

        var method = typeof(MergeSort<int>).GetMethod("MergeParts", BindingFlags.NonPublic | BindingFlags.Static);
        var result = method?.Invoke(null, [left, right, Ordering.Ascending]);

        Assert.That(result?.ToString(), Is.EqualTo("1 -> 2 -> 3 -> 4 -> 5 -> 6"));
    }

    [Test]
    public void TestSortNullMiddle()
    {
        var linkedList = new LinkedList<int>();

        linkedList.Sort();
        Assert.That(linkedList.Get(0), Is.Null);
    }
}
