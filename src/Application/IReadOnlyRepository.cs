namespace Application;

public interface IReadOnlyRepository<T>
{
    IEnumerable<T> GetAll();
}
