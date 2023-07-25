using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Helper;
using danj_backend.Model;
using danj_backend.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace danj_backend.EFCore
{
    public abstract class EFCoreRepository<TEntity, TContext> : IUsersRepository<TEntity>
            where TEntity : class, IEntity
            where TContext : ApiDbContext
    {
        private readonly TContext context;

        public EFCoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddUserAdmin(TEntity entity)
        {
            string hashpassword = BCrypt.Net.BCrypt.HashPassword(entity.password);
            entity.password = hashpassword;
            entity.isstatus = Convert.ToChar("0");
            entity.verified = Convert.ToChar("1");
            entity.imgurl = "No image";
            entity.userType = 1;
            entity.created_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            entity.updated_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteUAM(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsers(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public dynamic FetchAllUsersInformation(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).Select(t => new
            {
                t.Id,
                t.firstname,
                t.lastname,
                t.email,
                t.imgurl,
                t.userType,
                t.middlename
            }).ToList();
        }

        public Boolean FindAny(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public TEntity FindEmailExist(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public bool FindUsersExists(int id)
        {
            return context.Set<TEntity>().Any(x => x.Id == id);
        }

        public List<TEntity> GetAllUsers()
        {
            return context.Set<TEntity>().ToList();
        }

        public async Task<dynamic> PostNewDynamicRouteWhenLoginProcessed(DynamicRouting dynamicRouting)
        {
            var routeWhenExist = await context.dynamicRoutings.AnyAsync(x => x.access_level == dynamicRouting.access_level);
            DynamicRouting dynamicContext = new DynamicRouting();
            if (routeWhenExist)
            {
                return 301;
            }
            else
            {
                dynamicContext.access_level = dynamicRouting.access_level;
                dynamicContext.exactPath = dynamicRouting.exactPath;
                dynamicContext.requestId = dynamicRouting.requestId;
                dynamicContext.ToWhomRoute = dynamicRouting.ToWhomRoute;
                dynamicContext.created_at = dynamicRouting.created_at;
                await context.dynamicRoutings.AddAsync(dynamicContext);
                await context.SaveChangesAsync();
                return 200;
            }
        }

        public dynamic FindCorrespondingRoute(Expression<Func<DynamicRouting, bool>> predicate)
        {
            return context.Set<DynamicRouting>().Where(predicate).FirstOrDefault();
        }

        public async Task<dynamic> FindRouter(Guid requestId)
        {
            dynamic dynObject = new ExpandoObject();
            var result = await context.Set<DynamicRouting>()
            .Where(x => x.requestId == requestId).FirstOrDefaultAsync();
            dynObject.exactPath = result.exactPath;
            dynObject.access_level = result.access_level;
            return dynObject;
        }

        public TEntity UAM(TEntity entity)
        {
            if (entity.userType == Convert.ToChar("1"))
            {
                string hashpassword = BCrypt.Net.BCrypt.HashPassword(entity.password);
                entity.password = hashpassword;
                entity.isstatus = Convert.ToChar("1");
                entity.verified = Convert.ToChar("1");
                entity.imgurl = "No image";
                entity.userType = 1;
                entity.created_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
                entity.updated_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return entity;
            }
            else
            {
                string hashpassword = BCrypt.Net.BCrypt.HashPassword(entity.password);
                entity.password = hashpassword;
                entity.isstatus = Convert.ToChar("1");
                entity.verified = Convert.ToChar("0");
                entity.imgurl = "No image";
                entity.userType = 2;
                entity.created_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
                entity.updated_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool UpdateUsersPersonalDetails(PersonalDetails personalDetails)
        {
            var entity = context.Users.FirstOrDefault(x => x.Id == personalDetails.Id);
            if (entity != null)
            {
                entity.firstname = personalDetails.firstname;
                entity.middlename = personalDetails.middlename;
                entity.lastname = personalDetails.lastname;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUsersVerifiedAndStatus(string propstype, int id)
        {
            switch (propstype)
            {
                case "unlock":
                    var entityUnlock = context.Users.FirstOrDefault(x => x.Id == id);
                    if (entityUnlock != null)
                    {
                        entityUnlock.isstatus = Convert.ToChar("0");
                        context.SaveChanges();
                        return true;
                    }
                    break;
                case "lock":
                    var entityLock = context.Users.FirstOrDefault(x => x.Id == id);
                    if (entityLock != null)
                    {
                        entityLock.isstatus = Convert.ToChar("1");
                        context.SaveChanges();
                        return true;
                    }
                    break;
                case "verify":
                    var entityVerify = context.Users.FirstOrDefault(x => x.Id == id);
                    if (entityVerify != null)
                    {
                        entityVerify.verified = Convert.ToChar("1");
                        context.SaveChanges();
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}