using Models.Types;
using Models.Types.Common;

namespace UnitTests.Models.Types.Time.YearTests;

public sealed class DecadeBeginning
{
    [Fact]
    public void Returns_BeginningYearOfADecade_Given_Year()
    {
        var year = new Year(2024);
        var expected = new Year(2021);

        var actual = year.DecadeBeginning;
        
        Assert.Equal(expected, actual);
    }
}
