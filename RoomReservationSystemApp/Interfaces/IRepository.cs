namespace RoomReservationSystemApp;

public interface IRepository<T> where T : class 
{
    void Insert(T entity);
    T GetByRoomId(int entityId);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Delete(int entityId);
    void Save();
}