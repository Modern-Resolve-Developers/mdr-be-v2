using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.Helper;
using danj_backend.Model;

namespace danj_backend.Repository
{
    public interface IUsersRepository<T> where T : class, IEntity
    {
        Task<T> AddUserAdmin(T entity);
        public T FindEmailExist(Expression<Func<T, bool>> predicate);

        public Boolean FindAny(Expression<Func<T, bool>> predicate);

        public dynamic FetchAllUsersInformation(Expression<Func<T, bool>> predicate);

        public dynamic FindCorrespondingRoute(Expression<Func<DynamicRouting, bool>> predicate);

        public Boolean FindUsersExists(int id);

        public List<T> GetAllUsers();

        public T UAM(T entity);

        public Boolean UpdateUsersVerifiedAndStatus(string propstype, int id);

        public Boolean UpdateUsersPersonalDetails(PersonalDetails personalDetails);

        public Task<Boolean> DeleteUAM(int id);

        public Task<Boolean> DeleteUsers(int id);

        public Task<dynamic> PostNewDynamicRouteWhenLoginProcessed(DynamicRouting dynamicRouting);

        public Task<dynamic> FindRouter(Guid requestId);
    }
}