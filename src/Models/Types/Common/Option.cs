namespace Models.Types.Common;

public abstract class Option<T>
{
    public static implicit operator Option<T>(None _) => new None<T>();
    public static implicit operator Option<T>(T value) => new Some<T>(value);
}

public sealed class Some<T> : Option<T>
{
    public T Content { get; }
    public Some(T content) => Content = content;
}

public static class Option
{
    public static Option<T> Optional<T>(this T obj) => new Some<T>(obj);
}

public sealed class None<T> : Option<T>;

public sealed class None
{
    public static None Value { get; } = new();
    public static None<T> Of<T>() => new None<T>();
}

public static class OptionExtensions
{
    /// <summary>
    /// Applies a common function to an optional object.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="map"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Option<TResult> Map<T, TResult>(this Option<T> obj, Func<T, TResult> map) =>
        obj is Some<T> some ? new Some<TResult>(map(some.Content)) : new None<TResult>();

    /// <summary>
    /// Possibly filters out an optional object
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Option<T> Filter<T>(this Option<T> obj, Func<T, bool> predicate) =>
        obj is Some<T> some && !predicate(some.Content) ? new None<T>() : obj;

    /// <summary>
    /// Substitutes a default for a missing object
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="substitute"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> obj, T substitute) =>
        obj is Some<T> some ? some.Content : substitute;

    /// <summary>
    /// Substitutes a default delegate for a missing object
    /// Use this if the call of the substitute incurs cost. The option will only invoke
    /// the delegate if it is needed.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="substitute"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> obj, Func<T> substitute) =>
        obj is Some<T> some ? some.Content : substitute();
}
