using Models.Types.Common;

namespace UnitTests.Models.Types.Common.OptionTests;

public class Map
{
    [Fact]
    public void Returns_MappedResult_Given_OptionIsSome()
    {
        var optional = new Some<string>("hello");
        var expected = "HELLO";

        var result = optional.Map(s => s.ToUpperInvariant());
        var actual = result is Some<string> some ? some.Content : string.Empty;
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Returns_None_Given_OptionIsNone()
    {
        var optional = new None<string>();

        var result = optional.Map(s => s.ToUpperInvariant());

        Assert.IsType<None<string>>(result);
    }
}
