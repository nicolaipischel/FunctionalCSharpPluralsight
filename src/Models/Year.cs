namespace Models;

public record struct Year(int Number)
{
    Month GetMonth(int ordinal) =>
        ordinal >= 1 && ordinal <= 12
            ? new(new(this.Number), ordinal)
            : throw new ArgumentException(nameof(ordinal));
}
