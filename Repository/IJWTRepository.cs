using System.Linq.Expressions;
using danj_backend.Data;

namespace danj_backend.Repository;

public interface IJWTRepository<T> where T : class, IJWTToken
{
    Task<T> createUserOnJwt(T entity);
    public dynamic JWTDynamicQuery(Expression<Func<T, bool>> predicate);
    public dynamic JWTDynamicQueryFirstOrDefault(Expression<Func<T, bool>> predicate);
}