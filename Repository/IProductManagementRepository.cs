using danj_backend.Data;

namespace danj_backend.Repository;

public interface IProductManagementRepository<T> where T : class, IProductManagement
{
    Task<T> createProducts(T entity);
}