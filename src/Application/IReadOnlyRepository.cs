namespace Application;

public interface IReadOnlyRepository<T>
{
    IEnumerable<T> GetAll();
    T Find(Guid id);
}
