using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Model;
using danj_backend.Repository;

namespace danj_backend.EFCore
{
    public abstract class EFCoreTaskManagementRepository<TEntity, TContext> : ITaskManagementRepository<TEntity>
        where TEntity : class, ITaskManagement
        where TContext : ApiDbContext
    {
        private readonly TContext context;

        public EFCoreTaskManagementRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity createTask(TEntity task)
        {
            var random = new Random();
            var value = random.Next();
            task.taskCode= value;
            task.task_status = Convert.ToChar(task.task_status);
            task.created_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            task.updated_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            context.Set<TEntity>().Add(task);
            context.SaveChanges();
            return task;
        }

        public async Task<Boolean> DeleteTicket(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if(entity == null)
            {
                return false;
            }
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public List<TEntity> getAllTask()
        {
            return context.Set<TEntity>().Where(x => x.task_status == Convert.ToChar("1")).ToList();
        }

        public dynamic getAllUsers(char userType)
        {
            switch(userType)
            {
                case '2':
                    var devs = context.Users.Where(x => x.userType == userType).Select(t => new
                    {
                        t.firstname,
                        t.Id
                    }).ToList();
                    return devs;
                default: break;
            }
            return context.Users.ToList();
        }
    }
}
