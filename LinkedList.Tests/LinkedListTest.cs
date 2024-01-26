namespace LinkedList.Tests;

public class LinkedListTest
{
    [Test]
    public void TestListShouldBeEmpty()
    {
        var linkedList = new LinkedList<int>();

        Assert.That(linkedList.IsEmpty(), Is.True);
    }

    [Test]
    public void TestAddElement()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));

        Assert.That(linkedList.IsEmpty(), Is.False);
    }

    [Test]
    public void TestRemoveElement()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        Assert.That(linkedList.Count(), Is.EqualTo(1));

        linkedList.RemoveFirst();
        Assert.That(linkedList.Count(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveElementNull()
    {
        var linkedList = new LinkedList<int>();
        Assert.That(linkedList.Get(0), Is.Null);

        linkedList.RemoveFirst();
        Assert.That(linkedList.Get(0), Is.Null);
    }

    [Test]
    public void TestReverse()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        Assert.That(linkedList.ToString(), Is.EqualTo("3 -> 2 -> 1"));

        linkedList.Reverse();
        Assert.That(linkedList.ToString(), Is.EqualTo("1 -> 2 -> 3"));
    }

    [Test]
    public void TestClear()
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
    public void TestGetNull()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.That(linkedList.Get(3), Is.Null);
    }

    [Test]
    public void TestGetTail()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.That(linkedList.GetTail()!.Value, Is.EqualTo(1));
    }

    [Test]
    public void TestGetTailNull()
    {
        var linkedList = new LinkedList<int>();

        Assert.That(linkedList.GetTail(), Is.Null);
    }

    [Test]
    public void TestIsEmpty()
    {
        var linkedList = new LinkedList<int>();

        Assert.That(linkedList.IsEmpty(), Is.True);
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

    [Test]
    public void TestGenerateRandom()
    {
        var linkedList = LinkedList<int>.GenerateRandom(10);

        Assert.That(linkedList.Count(), Is.EqualTo(10));
    }
}
