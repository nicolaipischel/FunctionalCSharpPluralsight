using Models.Types;
using Models.Types.Common;

namespace Models.Time;

public static class DateTimeExtensions
{
    public static Year ToYear(this DateTime dateTime) => new (dateTime.Year);
}
