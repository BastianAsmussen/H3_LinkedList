using LinkedList;

namespace LinkedListe.Tests;

public class LinkedListTest
{
    [Fact]
    public void LinkedListShouldBeEmpty()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        Assert.True(linkedList.IsEmpty());
    }

    [Fact]
    public void AddElement()
    {
        var linkedList = new LinkedList.LinkedList<int>();
        linkedList.AddFirst(new Element<int>(1));

        Assert.False(linkedList.IsEmpty());
    }

    [Fact]
    public void RemoveElement()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        Assert.Equal(1, linkedList.Count());

        linkedList.RemoveFirst();
        Assert.Equal(0, linkedList.Count());
    }

    [Fact]
    public void ClearLinkedList()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));
        Assert.Equal(3, linkedList.Count());

        linkedList.Clear();
        Assert.Equal(0, linkedList.Count());
    }

    [Fact]
    public void TestCount()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.Equal(3, linkedList.Count());
    }

    [Fact]
    public void TestGet()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(3));

        Assert.Equal(1, linkedList.Get(2)?.Value);
    }

    [Fact]
    public void TestIsEmpty()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        Assert.True(linkedList.IsEmpty());
    }

    [Fact]
    public void TestSortAscending()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        Assert.Equal("2 -> 3 -> 1", linkedList.ToString());

        linkedList.Sort();
        Assert.Equal("1 -> 2 -> 3", linkedList.ToString());
    }

    [Fact]
    public void TestSortDescending()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(1));
        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        Assert.Equal("2 -> 3 -> 1", linkedList.ToString());

        linkedList.Sort(SortOrder.Descending);
        Assert.Equal("3 -> 2 -> 1", linkedList.ToString());
    }

    [Fact]
    public void TestToString()
    {
        var linkedList = new LinkedList.LinkedList<int>();

        linkedList.AddFirst(new Element<int>(3));
        linkedList.AddFirst(new Element<int>(2));
        linkedList.AddFirst(new Element<int>(1));

        Assert.Equal("1 -> 2 -> 3", linkedList.ToString());
    }
}
