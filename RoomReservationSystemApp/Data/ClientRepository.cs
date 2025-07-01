using Microsoft.EntityFrameworkCore;

namespace RoomReservationSystemApp;

public class ClientRepository 
{
    private readonly ReservationDbContext _context = null;
    private DbSet<ClientDB> Client = null;

    public ClientRepository()
    {
        _context = new ReservationDbContext();
        Client = _context.Set<ClientDB>();
    }
    
    public void Insert(ClientDB entity)
    {
        Client.Add(entity);
    }
    
    public ClientDB GetByClientId(int entityId)
    {
        return Client.Find(entityId);
    }
    
    public IEnumerable<ClientDB> GetAll()
    {
        return Client.ToList();
    }
    
    public void Update(ClientDB entity)
    {
        Client.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int entityId)
    {
        Client.Remove(GetByClientId(entityId));
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}