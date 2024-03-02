namespace Models;

public static class DateTimeExtensions
{
    public static Year ToYear(this DateTime dateTime) => new (dateTime.Year);
    public static IEnumerable<Month> GetDecadeMonths(this DateTime datetime) =>
        Enumerable.Range(datetime.Year.ToDecadeBeginning(), 10)
            .Select(year => new Year(year))
            .SelectMany(year => year.Months);

    private static int ToDecadeBeginning(this int year) => year / 10 * 10 + 1;


}
