using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Repository;

namespace danj_backend.EFCore;

public abstract class EFCoreJwtRepository<TEntity, TContext> : IJWTRepository<TEntity>
    where TEntity : class, IJWTToken
    where TContext : ApiDbContext
{
    private readonly TContext context;

    public EFCoreJwtRepository(TContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> createUserOnJwt(TEntity entity)
    {
        string hashpassword = BCrypt.Net.BCrypt.HashPassword(entity.jwtpassword);
        entity.jwtpassword = hashpassword;
        entity.isValid = Convert.ToChar("1");
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public dynamic JWTDynamicQuery(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Any(predicate);
    }

    public dynamic JWTDynamicQueryFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Where(predicate).FirstOrDefault();
    }
}