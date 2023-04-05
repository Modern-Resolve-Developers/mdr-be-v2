using danj_backend.Data;

namespace danj_backend.Repository;

public interface IProductFeatCategoryRepository<T> where T : class, IProdCategFeatures
{
    List<T> getAllMultiSelect();
}