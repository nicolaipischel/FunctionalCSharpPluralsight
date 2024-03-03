using System.Globalization;
using Models.Time;
using Models.Types;
using Models.Types.Common;

namespace UnitTests.Models.Time.DateTimeExtensionsTests;

public sealed class ToYear
{
    [Fact]
    public void Returns_YearRecord_ContainingYear_Given_DateTime()
    {
        var dateTime = new DateTime(2024, 03, 02, calendar: new GregorianCalendar());
        var expected = new Year(2024);

        var actual = dateTime.ToYear();
        
        Assert.Equal(expected, actual);
    }
}
