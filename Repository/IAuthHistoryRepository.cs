using danj_backend.Data;
using System.Linq.Expressions;

namespace danj_backend.Repository
{
    public interface IAuthHistoryRepository<T> where T : class, IAuthHistory
    {
        public T saveAuthHistory(T authHistory);
        public dynamic FetchAuthHistoryTokenById(Expression<Func<T, bool>> predicate);

        public T ValueFetchAuthHistoryTokenById(Expression<Func<T, bool>> predicate);

        public Boolean FindInAuthHistoryIfExist(Expression<Func<T, bool>> predicate);

    }
}
