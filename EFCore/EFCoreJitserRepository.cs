using System.Linq.Expressions;
using danj_backend.Data;
using danj_backend.DB;
using danj_backend.Model;
using danj_backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace danj_backend.EFCore;

public class EFCoreJitserRepository<TEntity, TContext> : IJitserRepository<TEntity>
where TEntity : class, IJitser
where TContext: ApiDbContext
{
    private readonly TContext context;

    public EFCoreJitserRepository(TContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> storeMeetDetails(TEntity entity)
    {
        entity.createdBy = "Administrator";
        entity.roomPassword = entity.roomPassword == "no-password-public-room" ? "no-password-public-room" : BCrypt.Net.BCrypt.HashPassword(entity.roomPassword);
        entity.roomStatus = Convert.ToChar("1");
        entity.createdAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
        entity.updatedAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public Boolean meetDetailsCheck(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Any(predicate);
    }

    public async Task<dynamic> getAllRooms()
    {
        
        var result = await (from c in context.Set<TEntity>()
            join o in context.JitsiJoinedPersonsEnumerable
                on c.id equals o.roomId into joinedGroup
            where c.roomStatus == Convert.ToChar("1") select new
            {
                 id = c.id,
                 roomName = c.roomName,
                 isPrivate = c.isPrivate,
                 roomPassword = c.roomPassword,
                 roomStatus = c.roomStatus,
                 createdBy = c.createdBy,
                 createdAt = c.createdAt,
                 updatedAt = c.updatedAt,
                 roomUrl = c.roomUrl,
                 count = joinedGroup.Count()
            }).ToListAsync();
        return result;
    }

    public async Task<dynamic> WhenJoinMeet(int roomId, string name)
    {
        var IsNameExist = await context.JitsiJoinedPersonsEnumerable.AnyAsync(x => x.name == name);
        if (IsNameExist)
        {
            return "name_exist";
        }
        else
        {
            JitsiJoinedPersons jitsiJoinedPersons = new JitsiJoinedPersons();
            jitsiJoinedPersons.name = name;
            jitsiJoinedPersons.roomId = roomId;
            jitsiJoinedPersons.createdAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            jitsiJoinedPersons.updatedAt = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            context.JitsiJoinedPersonsEnumerable.Add(jitsiJoinedPersons);
            await context.SaveChangesAsync();
            return "joined";
        }
    }

    public async Task<dynamic> HangoutMeet(string name)
    {
        var findNameInMeet = await context.JitsiJoinedPersonsEnumerable.AnyAsync(x => x.name == name);
        var entity = await context.JitsiJoinedPersonsEnumerable.FindAsync(name);
        if (findNameInMeet)
        {
            context.JitsiJoinedPersonsEnumerable.Remove(entity);
            context.SaveChangesAsync();
        }

        return "remove_from_meeting";
    }

    public async Task<dynamic> deleteRoom(int id)
    {
        var findAnyMeetingRoom = await context.Set<TEntity>().AnyAsync(x => x.id == id);
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (findAnyMeetingRoom)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChangesAsync();
        }

        return "deleted";
    }
}