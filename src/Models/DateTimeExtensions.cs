namespace Models;

public static class DateTimeExtensions
{
    public static Year ToYear(this DateTime dateTime) => new (dateTime.Year);
}
