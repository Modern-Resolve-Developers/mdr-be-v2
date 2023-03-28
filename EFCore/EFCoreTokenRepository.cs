using danj_backend.Authentication;
using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Model;
using danj_backend.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace danj_backend.EFCore
{
    public abstract class EFCoreTokenRepository<TEntity, TTokeContext> : ITokenizationRepository<TEntity> where TEntity : class, IToken where TTokeContext : ApiDbContext
    {
        private readonly TTokeContext context;

        public EFCoreTokenRepository(TTokeContext context)
        {
            this.context = context;
        }

        public dynamic ChangeToZeroIsValid(int refid)
        {
            var result = context.Database.ExecuteSql($"Base_tokenization_destroytoken_procedure @referenceId={refid}, @isValid='0', @StatementType='auth-token-destroy'");
            return result;
        }

        public TEntity CreateToken(TEntity entity)
        {
            entity.token = new DataAuth().Encrypt(Guid.NewGuid().ToString());
            entity.isValid = Convert.ToChar("1");
            DateTime startDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            DateTime expiryDate = startDate.AddDays(30);
            entity.isExpired = Convert.ToChar("0");
            entity.expiration = expiryDate;
            entity.created_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            entity.updated_at = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy/MM/dd"));
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }


        public dynamic FetchToken(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).Select(t => new
            {
                t.token
            }).ToList();
        }

        public bool FindInTokenIfExist(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public dynamic FindUsersById(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public dynamic IdentifyAuthentication(int userid)
        {
            var result = context.Set<TEntity>().Any(x => x.userId == userid && x.isValid == Convert.ToChar("1"));
            var getUserType = context.Users.Where(x => x.Id == userid).FirstOrDefault();
            if(result)
            {
                if(getUserType != null)
                {
                    if(getUserType.userType == Convert.ToChar('1'))
                    {
                        var role = "Administrator";
                        return role;
                    }
                    else if(getUserType.userType == Convert.ToChar('2'))
                    {
                        var role = "Developers";
                        return role;
                    }
                    else
                    {
                        var role = "Client";
                        return role;
                    }
                }
            }
            else
            {
                return "Not_found";
            }
            return result;
        }
    }
}