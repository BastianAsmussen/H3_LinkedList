namespace LinkedList.Tests;

public class SortingTest
{
    [Test]
    public void TestSortAscending()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(1));
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 2 -> 3"));

        linkedList.Sort();
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 2 -> 3"));
    }

    [Test]
    public void TestSortDescending()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        Assert.That(linkedList.ToString(), Is.EqualTo("3 -> 2 -> 1"));

        linkedList.Sort(Ordering.Descending);
        Assert.That(linkedList.ToString(), Is.EqualTo("3 -> 2 -> 1"));
    }

    [Test]
    public void TestSortEmpty()
    {
        var linkedList = new LinkedList<int>();
        Assert.That(linkedList.ToString(), Is.EqualTo(""));

        linkedList.Sort();
        Assert.That(linkedList.ToString(), Is.EqualTo(""));
    }

    [Test]
    public void TestSortOneElement()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        Assert.That(linkedList.ToString(), Is.EqualTo("1"));

        linkedList.Sort();
        Assert.That(linkedList.ToString(), Is.EqualTo("1"));
    }

    [Test]
    public void TestCompareNull()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.Throws<ArgumentOutOfRangeException>(() => linkedList.Sort((Ordering)2));
    }
}
