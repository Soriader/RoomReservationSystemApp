using Microsoft.EntityFrameworkCore;

namespace RoomReservationSystemApp;

public class RoomReservationRepository : IRepository<RoomReservationDB>
{
    private readonly ReservationDbContext _context = null;
    private DbSet<RoomReservationDB> Rooms = null;

    public RoomReservationRepository()
    {
        _context = new ReservationDbContext();
        Rooms = _context.Set<RoomReservationDB>();
    }
    
    public void Insert(RoomReservationDB entity)
    {
        Rooms.Add(entity);
    }
    
    public RoomReservationDB GetByType(string type)
    {
        return Rooms.FirstOrDefault(b => b.Type.ToLower() == type.ToLower());
    }
    
    public RoomReservationDB GetByRoomId(int entityId)
    {
        return Rooms.Find(entityId);
    }
    
    public IEnumerable<RoomReservationDB> GetAll()
    {
        return Rooms.ToList();
    }
    
    public void Update(RoomReservationDB entity)
    {
        Rooms.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int entityId)
    {
        Rooms.Remove(GetByRoomId(entityId));
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    
}