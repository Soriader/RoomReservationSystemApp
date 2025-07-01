using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomReservationSystemApp;

public class ClientDB
{
    [Key]
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public int? RoomReservationDBId { get; set; }
    public RoomReservationDB RoomReservation { get; set; }
}