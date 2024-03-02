namespace Models;

public record struct Year(int Number)
{
    public IEnumerable<Month> Months =>
        this.GetMonths(this);
    
    public Year DecadeBeginning => new(this.Number / 10 * 10 + 1);

    public IEnumerable<Year> Decade =>
        Enumerable.Range(this.DecadeBeginning.Number, 10)
            .Select(number => new Year(number));
    private IEnumerable<Month> GetMonths(Year year) =>
        Enumerable.Range(1, 12).Select(ordinal => new Month(year, ordinal));
}
