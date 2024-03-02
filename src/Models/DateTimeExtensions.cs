namespace Models;

public static class DateTimeExtensions
{
    public static Year ToYear(this DateTime dateTime) => new (dateTime.Year);
    public static IEnumerable<Month> GetYearMonths(this DateTime dateTime) =>
        dateTime.Year.GetYearMonths();

    public static IEnumerable<Month> GetDecadeMonths(this DateTime datetime) =>
        Enumerable.Range(datetime.Year.ToDecadeBeginning(), 10).SelectMany(GetYearMonths);

    private static int ToDecadeBeginning(this int year) => year / 10 * 10 + 1;

    private static IEnumerable<Month> GetYearMonths(this int year) =>
        Enumerable.Range(1, 12).Select(month => new Month(new(year), month));


}
