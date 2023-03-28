using danj_backend.Data;
using danj_backend.Model;

namespace danj_backend.Repository
{
    public interface ITaskManagementRepository<T> where T : class, ITaskManagement
    {
        public T createTask(T task);
        public dynamic getAllUsers(char userType);

        List<T> getAllTask();

        public Task<Boolean> DeleteTicket(int id);
    }
}
