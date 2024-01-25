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
    public void ElementToString()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.That(element.ToString(), Is.EqualTo("1 -> 2"));
    }
}
