namespace Models;

public record struct Year(int Number)
{
    public IEnumerable<Month> Months =>
        this.GetMonths(this);

    private IEnumerable<Month> GetMonths(Year year) =>
        Enumerable.Range(1, 12).Select(ordinal => new Month(year, ordinal));
}
