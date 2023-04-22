using System.Linq.Expressions;
using danj_backend.Data;

namespace danj_backend.Repository;

public interface IJitserRepository<T> where T : class, IJitser
{
    Task<T> storeMeetDetails(T entity);
    public Boolean meetDetailsCheck(Expression<Func<T, bool>> predicate);

    Task<List<T>> getAllRooms();
}