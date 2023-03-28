using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.Helper;
using danj_backend.Model;

namespace danj_backend.Repository
{
    public interface ITokenizationRepository<T> where T : class, IToken
    {
        public T CreateToken(T entity);

        public dynamic FetchToken(Expression<Func<T, bool>> predicate);

        public dynamic FindUsersById(Expression<Func<T, bool>> predicate);

        public dynamic ChangeToZeroIsValid(int refid);

        public Boolean FindInTokenIfExist(Expression<Func<T, bool>> predicate);

        public dynamic IdentifyAuthentication(int userid);
    }
}