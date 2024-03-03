using Models.Types.Common;

namespace UnitTests.Models.Types.Common.OptionTests;

public class Filter
{
    [Fact]
    public void Returns_FilteredResult_Given_OptionIsSomeAndItSatisfiesFilter()
    {
        var optional = new Some<string>("object");
        var expected = "object";

        var result = optional.Filter(s => s.Contains(expected));
        var actual = result is Some<string> some ? some.Content : string.Empty;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Returns_None_Given_OptionIsNone()
    {
        var optional = new None<string>();

        var result = optional.Filter(s => s.Contains("abc"));

        Assert.IsType<None<string>>(result);
    }
}
