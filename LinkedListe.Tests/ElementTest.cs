using LinkedList;

namespace LinkedListe.Tests;

public class ElementTest
{
    [Fact]
    public void ElementShouldHaveValue()
    {
        var element = new Element<int>(1);

        Assert.Equal(1, element.Value);
    }

    [Fact]
    public void ElementNextIsNull()
    {
        var element = new Element<int>(1);

        Assert.Null(element.Next);
    }

    [Fact]
    public void ElementNextNotNull()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.NotNull(element.Next);
    }

    [Fact]
    public void ElementToString()
    {
        var next = new Element<int>(2);
        var element = new Element<int>(1, next);

        Assert.Equal("1 -> 2", element.ToString());
    }
}
