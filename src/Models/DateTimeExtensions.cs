namespace Models;

public static class DateTimeExtensions
{
    public static IEnumerable<(int year, int month)> GetYearMonths(this DateTime dateTime) =>
        dateTime.Year.GetYearMonths();

    public static IEnumerable<(int year, int month)> GetDecadeMonths(this DateTime datetime) =>
        Enumerable.Range(datetime.Year.ToDecadeBeginning(), 10).SelectMany(GetYearMonths);

    private static int ToDecadeBeginning(this int year) => year / 10 * 10 + 1;

    private static IEnumerable<(int year, int month)> GetYearMonths(this int year) =>
        Enumerable.Range(1, 12).Select(month => (year, month));


}
