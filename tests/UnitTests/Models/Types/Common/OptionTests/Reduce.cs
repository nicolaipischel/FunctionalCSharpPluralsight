using Models.Types.Common;

namespace UnitTests.Models.Types.Common.OptionTests;

public class Reduce
{
    [Fact]
    public void Returns_Content_Given_OptionIsSome()
    {
        var expected = "hello";
        var optional = new Some<string>(expected);

        var actual = optional.Reduce("test");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Returns_Substitute_Given_OptionIsNone()
    {
        var optional = new None<string>();
        var expected = "test";
        var actual = optional.Reduce(expected);

        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Returns_ContentResult_Given_OptionIsSome()
    {
        var expected = "hello";
        var optional = new Some<string>(expected);

        var actual = optional.Reduce(() => "Test");
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Returns_SubstituteEvaluation_Given_OptionIsNone()
    {
        var optional = new None<string>();
        var expected = "Test";
        var actual = optional.Reduce(() => expected);

        Assert.Equal(expected, actual);
    }
}
