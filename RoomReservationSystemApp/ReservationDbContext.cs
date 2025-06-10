namespace RoomReservationSystemApp;

using Microsoft.EntityFrameworkCore;

public class ReservationDbContext : DbContext
{
    public DbSet<RoomReservationDB> Rooms { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Połączenie z lokalną bazą SQL Server
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RoomReservationSystemApp;Integrated Security=True;TrustServerCertificate=true;");
        
    }
}