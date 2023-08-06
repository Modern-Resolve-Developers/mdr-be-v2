using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.Helper;
using danj_backend.Helper.Router;
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

        public Task<dynamic> PostNewDynamicRouteWhenLoginProcessed(string dynamicRouting);

        public Task<dynamic> FindRouter(RouteWithRequestId pRequestId);

        public Task<dynamic> GoogleAccountEmailVerifier(string email);

        public Task<dynamic> CustomerAccountCreation(T entity, string key);

        public Task<dynamic> CustomerCheckEmail(string email);

        public Boolean CheckUsersData();
        public Task<dynamic> login(LoginHelper loginHelper);
    }
}