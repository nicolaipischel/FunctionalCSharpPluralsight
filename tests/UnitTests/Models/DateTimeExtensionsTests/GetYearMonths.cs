using System.Globalization;
using Models;

namespace UnitTests.Models.DateTimeExtensionsTests;

public sealed class GetYearMonths
{
    [Fact]
    public void Returns_YearAndMonths_Given_DateTime()
    {
        var dateTime = new DateTime(2024, 03, 02, calendar: new GregorianCalendar());
        var expected = new[]
        {
            new Month(new(2024), 1),
            new Month(new(2024), 2),
            new Month(new(2024), 3),
            new Month(new(2024), 4),
            new Month(new(2024), 5),
            new Month(new(2024), 6),
            new Month(new(2024), 7),
            new Month(new(2024), 8),
            new Month(new(2024), 9),
            new Month(new(2024), 10),
            new Month(new(2024), 11),
            new Month(new(2024), 12)
        };

        var actual = dateTime.GetYearMonths();
        
        Assert.Equal(expected, actual);
    }
}
