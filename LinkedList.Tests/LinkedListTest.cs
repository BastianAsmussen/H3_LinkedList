namespace LinkedList.Tests;

public class LinkedListTest
{
    [Test]
    public void LinkedListShouldBeEmpty()
    {
        var linkedList = new LinkedList<int>();

        Assert.That(linkedList.IsEmpty(), Is.True);
    }

    [Test]
    public void AddElement()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));

        Assert.That(linkedList.IsEmpty(), Is.False);
    }

    [Test]
    public void RemoveElement()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        Assert.That(linkedList.Count(), Is.EqualTo(1));

        linkedList.RemoveFirst();
        Assert.That(linkedList.Count(), Is.EqualTo(0));
    }

    [Test]
    public void ClearLinkedList()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        Assert.That(linkedList.Count(), Is.EqualTo(3));

        linkedList.Clear();
        Assert.That(linkedList.Count(), Is.EqualTo(0));
    }

    [Test]
    public void TestCount()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.That(linkedList.Count(), Is.EqualTo(3));
    }

    [Test]
    public void TestGet()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.That(linkedList.Get(2)?.Value!, Is.EqualTo(1));
    }

    [Test]
    public void TestIsEmpty()
    {
        var linkedList = new LinkedList<int>();

        Assert.That(linkedList.IsEmpty(), Is.True);
    }

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

        linkedList.Sort(SortOrder.Descending);
        Assert.That(linkedList.ToString(), Is.EqualTo("3 -> 2 -> 1"));
    }

    [Test]
    public void TestToString()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(1));

        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 2 -> 3"));
    }
}
