using Models.Types.Common;

namespace Application;

public interface IReadOnlyRepository<T>
{
    IEnumerable<T> GetAll();
    Option<T> TryFind(Guid id);
}
