using System.Linq.Expressions;
using danj_backend.Data;

namespace danj_backend.Repository;

public interface IJitserRepository<T> where T : class, IJitser
{
    Task<T> storeMeetDetails(T entity);
    public Boolean meetDetailsCheck(Expression<Func<T, bool>> predicate);

    Task<dynamic> getAllRooms();
    Task<dynamic> WhenJoinMeet(int roomId, string name);
    Task<dynamic> HangoutMeet(string name);
    Task<dynamic> deleteRoom(int id);
}