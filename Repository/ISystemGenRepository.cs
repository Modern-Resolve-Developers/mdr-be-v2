using danj_backend.Data;
using danj_backend.Model;

namespace danj_backend.Repository;

public interface ISystemGenRepository<T> where T: class, ISystemGen
{
    public T genSystemGen(T entity);
}