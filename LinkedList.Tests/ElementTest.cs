namespace LinkedList.Tests;

public class ElementTest
{
    [Test]
    public void ElementShouldHaveValue()
    {
        var element = new Element<int>(1);

        Assert.That(element.Value, Is.EqualTo(1));
    }

    [Test]
    public void ElementNextIsNull()
    {
        var element = new Element<int>(1);

        Assert.That(element.Next, Is.Null);
    }

    [Test]
    public void ElementNextNotNull()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.That(element.Next, Is.Not.Null);
    }

    [Test]
    public void ElementGetTail()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.That(element.GetTail(), Is.EqualTo(next));
    }

    [Test]
    public void ElementGetTailNull()
    {
        var first = (Element<int>?)null;

        Assert.That(first?.GetTail(), Is.Null);
    }

    [Test]
    public void ElementGetTailOneElement()
    {
        var second = new Element<int>(2);
        var first = new Element<int>(1, second);

        Assert.That(first.GetTail(), Is.EqualTo(second));
    }

    [Test]
    public void ElementToString()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.That(element.ToString(), Is.EqualTo("1 -> 2"));
    }
}
