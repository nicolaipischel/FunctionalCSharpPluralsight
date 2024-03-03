using Models.Types;
using Models.Types.Common;

namespace UnitTests.Models.Types.Time.YearTests;

public sealed class TryGetMonth
{
    [Fact]
    public void ReturnsMonth_Given_MonthExists()
    {
        var year = new Year(2024);
        var validOrdinal = 8;
        var expected = new[] { new Month(year, 8) };

        var actual = year.TryGetMonth(validOrdinal);
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ReturnsEmpty_Given_MonthDoesNotExist()
    {
        var year = new Year(2024);
        var invalidOrdinal = 13;

        var actual = year.TryGetMonth(invalidOrdinal);
        Assert.Empty(actual);
    }
}
