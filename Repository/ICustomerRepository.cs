using danj_backend.Data;

namespace danj_backend.Repository;

public interface ICustomerRepository<T> where T : class, ICustomers
{
    Task<dynamic> GoogleAuthLogin(string email);
    Task<T> ClientAccountCreation(T entity);
}