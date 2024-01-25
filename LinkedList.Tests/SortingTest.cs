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
        Assert.That(QuickSort<int>.Sort(null, Ordering.Ascending), Is.Null);
    }

    [Test]
    public void TestSortNoNext()
    {
        var element = new Element<int>(1);

        Assert.Multiple(() =>
        {
            Assert.That(element.Next, Is.Null);
            Assert.That(QuickSort<int>.Sort(element, Ordering.Ascending)?.ToString(), Is.EqualTo("1"));
        });
    }

    [Test]
    public void TestSortOneElement()
    {
        var element = new Element<int>(1);

        Assert.Multiple(() =>
        {
            Assert.That(element.Next, Is.Null);
            Assert.That(QuickSort<int>.Sort(element, Ordering.Ascending)?.ToString(), Is.EqualTo("1"));
        });
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
}
