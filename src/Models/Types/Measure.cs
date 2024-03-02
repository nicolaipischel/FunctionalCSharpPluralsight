namespace Models.Types;

// This is the type (serves as the entry point of the concept)
public abstract record Measure(string Unit);
public record DiscreteMeasure(string Unit, uint Value) : Measure(Unit);
public record ContinousMeasure(string Unit, decimal Value) : Measure(Unit);

public static class MeasureExtensions
{
    public static Measure AsDiscriminatedUnion(this Measure m) =>
        m switch
        {
            DiscreteMeasure or ContinousMeasure => m,
            _ => throw new InvalidOperationException(
                $"Not defined for object of type {m?.GetType().Name ?? "<null>"}")
        };

    public static TResult MapAny<TResult>(
        this Measure m,
        Func<DiscreteMeasure, TResult> discrete,
        Func<ContinousMeasure, TResult> continious) =>
        m.AsDiscriminatedUnion() switch
        {
            DiscreteMeasure d => discrete(d),
            ContinousMeasure c => continious(c),
            _ => default!
        };
}
