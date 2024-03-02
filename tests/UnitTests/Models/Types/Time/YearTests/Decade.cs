using Models.Types;

namespace UnitTests.Models.Types.Time.YearTests;

public sealed class Decade
{
    [Fact]
    public void Returns_YearsInADecade_Given_Year()
    {
        var year = new Year(2024);
        var expected = new Year[]
        {
            new(2021),
            new(2022),
            new(2023),
            new(2024),
            new(2025),
            new(2026),
            new(2027),
            new(2028),
            new(2029),
            new(2030)
        };

        var actual = year.Decade;
        
        Assert.Equal(expected, actual);
    }
}
