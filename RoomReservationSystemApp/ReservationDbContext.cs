namespace RoomReservationSystemApp;

using Microsoft.EntityFrameworkCore;

public class ReservationDbContext : DbContext
{
    public DbSet<RoomReservationDB> Rooms { get; set; }
    public DbSet<ClientDB> Client { get; set; } 

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RoomReservationSystemApp;Integrated Security=True;TrustServerCertificate=true;");
    }
}