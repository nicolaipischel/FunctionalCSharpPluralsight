using System.Globalization;
using Models;

namespace UnitTests.Models.DateTimeExtensions;

public sealed class GetYearMonths
{
    [Fact]
    public void Returns_YearAndMonths_Given_DateTime()
    {
        var dateTime = new DateTime(2024, 03, 02, calendar: new GregorianCalendar());
        var expected = new[]
        {
            (2024, 1),
            (2024, 2),
            (2024, 3),
            (2024, 4),
            (2024, 5),
            (2024, 6),
            (2024, 7),
            (2024, 8),
            (2024, 9),
            (2024, 10),
            (2024, 11),
            (2024, 12)
        };

        var actual = dateTime.GetYearMonths();
        
        Assert.Equal(expected, actual);
    }
}
