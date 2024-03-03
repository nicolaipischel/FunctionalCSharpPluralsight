using Models.Types;
using Models.Types.Common;

namespace UnitTests.Models.Types.Time.YearTests;

public sealed class Months
{
    [Fact]
    public void Returns_OrdinalMonths_ForAYear()
    {
        var year = new Year(2024);
        var expected = new[]
        {
            new Month(new Year(2024), 1),
            new Month(new Year(2024), 2),
            new Month(new Year(2024), 3),
            new Month(new Year(2024), 4),
            new Month(new Year(2024), 5),
            new Month(new Year(2024), 6),
            new Month(new Year(2024), 7),
            new Month(new Year(2024), 8),
            new Month(new Year(2024), 9),
            new Month(new Year(2024), 10),
            new Month(new Year(2024), 11),
            new Month(new Year(2024), 12),
        };

        var actual = year.Months;
        
        Assert.Equal(expected, actual);

    }
}
